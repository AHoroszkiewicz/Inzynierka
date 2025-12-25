using UnityEngine;
using DG.Tweening;

public class TitlePanelAnimation : MonoBehaviour
{
    [SerializeField] private Transform leftPencil;
    [SerializeField] private Transform rightPencil;
    [SerializeField] private Vector3 pencilEndPos;
    [SerializeField] private Transform[] explosion;
    [SerializeField] private Vector3 explosionEndScale;
    [SerializeField] private float animationDuration = 1.0f;

    void Start()
    {
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        var mainSeq = DOTween.Sequence();

        mainSeq.Append(leftPencil.DOLocalMove(pencilEndPos, animationDuration).SetEase(Ease.OutBack));
        mainSeq.Join(rightPencil.DOLocalMove(pencilEndPos, animationDuration).SetEase(Ease.OutBack));

        if (explosion != null && explosion.Length > 0)
        {
            var explosionSeq = DOTween.Sequence();
            foreach (var exp in explosion)
            {
                explosionSeq.Join(exp.DOScale(explosionEndScale, animationDuration).SetEase(Ease.OutBack));
            }

            mainSeq.Append(explosionSeq);
        }

        mainSeq.Play();
    }
}
