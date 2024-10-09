using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Sound Clips")]
    public AudioClip[] backgroundMusicClips;   // 배경음 클립 배열
    public AudioClip[] sfxClips;               // 효과음 클립 배열

    [Header("Audio Sources")]
    public AudioSource backgroundMusicSource;  // 배경음용 오디오 소스
    public GameObject soundPrefab;             // 효과음 재생용 프리팹
    public int poolSize = 10;                  // 오브젝트 풀 크기
    private List<AudioSource> soundPool = new List<AudioSource>(); // 오디오 소스 풀

    private void Awake()
    {
        // 싱글톤 패턴 설정
        if (instance == null)
        {
            instance = this;
            InitializeSoundPool();              // 효과음 풀 초기화
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 배경음 재생
    public void PlayBackgroundMusic(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < backgroundMusicClips.Length)
        {
            backgroundMusicSource.clip = backgroundMusicClips[clipIndex];
            backgroundMusicSource.loop = true;  // 배경음 반복 재생
            backgroundMusicSource.Play();
        }
    }

    // 배경음 멈추기
    public void StopBackgroundMusic()
    {
        backgroundMusicSource.Stop();
    }

    // 효과음 풀 초기화
    private void InitializeSoundPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject soundObj = Instantiate(soundPrefab);  // 사운드 프리팹 생성
            soundObj.transform.SetParent(transform);         // SoundManager의 자식으로 설정
            soundObj.SetActive(false);                       // 처음엔 비활성화
            soundPool.Add(soundObj.GetComponent<AudioSource>()); // 오디오 소스를 풀에 추가
        }
    }

    // 사용 가능한 오디오 소스 찾기
    private AudioSource GetAvailableSoundSource()
    {
        foreach (AudioSource source in soundPool)
        {
            if (!source.gameObject.activeInHierarchy)  // 비활성화된 오브젝트를 찾음
            {
                source.gameObject.SetActive(true);      // 활성화
                return source;
            }
        }

        // 풀에 사용 가능한 소스가 없다면 새로운 오브젝트 생성
        GameObject newSoundObj = Instantiate(soundPrefab);
        newSoundObj.transform.SetParent(transform);
        AudioSource newSource = newSoundObj.GetComponent<AudioSource>();
        soundPool.Add(newSource);
        return newSource;
    }

    // 효과음 재생
    public void PlaySFX(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < sfxClips.Length)
        {
            AudioSource source = GetAvailableSoundSource();
            source.clip = sfxClips[clipIndex];
            source.Play();

            // 재생이 끝난 후 비활성화
            StartCoroutine(DeactivateAfterPlay(source, sfxClips[clipIndex].length));
        }
    }

    // 재생이 끝난 후 오브젝트 비활성화
    private IEnumerator DeactivateAfterPlay(AudioSource source, float delay)
    {
        yield return new WaitForSeconds(delay);
        source.gameObject.SetActive(false);  // 다시 풀로 반환
    }
}
