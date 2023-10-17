using UnityEngine;
using System.Collections;

public class MonsterBomb : MonoBehaviour
{
    public static MonsterBomb instance;

    public GameObject effectPrefab;
    private Animator animator;
    private Animation bombAnimation;
    private bool isEffectPlaying = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        instance = this;
    }

    // 이 함수는 애니메이션 이벤트로 호출됩니다.
    public void PlayEffect()
    {
        if (!isEffectPlaying)
        {
            StartCoroutine(PlayEffectCoroutine());
        }
    }

    IEnumerator PlayEffectCoroutine()
    {
        isEffectPlaying = true;

        // 이펙트를 생성하고 위치를 설정합니다.
        GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

        // 이펙트가 종료될 때까지 대기합니다.
        yield return new WaitForSeconds(effect.GetComponent<ParticleSystem>().main.duration);
        isEffectPlaying = false;
    }
}






