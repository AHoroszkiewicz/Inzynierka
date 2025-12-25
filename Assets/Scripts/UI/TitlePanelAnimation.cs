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

    // Plan (pseudocode):
    // 1. Utwórz g³ówn¹ sekwencjê DOTween.
    // 2. Do sekwencji dodaj jednoczesne przesuniêcie lewego i prawego o³ówka:
    //    - Append leftPencil.DOMoveX(...)
    //    - Join rightPencil.DOMoveX(...) (aby bieg³y równolegle z lewym)
    // 3. Utwórz oddzieln¹ sekwencjê dla eksplozji.
    //    - Dla ka¿dego elementu explosion do³¹cz jego DOScale(...) jako Join,
    //      ¿eby wszystkie eksploduj¹ce elementy skalowa³y siê jednoczeœnie.
    // 4. Po zakoñczeniu ruchu o³ówków Append explosionSequence do g³ównej sekwencji,
    //    dziêki czemu skalowanie zacznie siê dopiero po zakoñczeniu ruchu o³ówków.
    // 5. Odtwórz sekwencjê.
    private void PlayAnimation()
    {
        // G³ówna sekwencja: najpierw o³ówki, potem eksplozje
        var mainSeq = DOTween.Sequence();

        // Dodaj ruch o³ówków (lewy i prawy jednoczeœnie)
        mainSeq.Append(leftPencil.DOLocalMove(pencilEndPos, animationDuration).SetEase(Ease.OutBack));
        pencilEndPos.x = -pencilEndPos.x; // Odwróæ pozycjê X dla prawego o³ówka
        mainSeq.Join(rightPencil.DOLocalMove(pencilEndPos, animationDuration).SetEase(Ease.OutBack));

        // Sekwencja eksplozji: wszystkie elementy skaluj¹ siê równoczeœnie
        if (explosion != null && explosion.Length > 0)
        {
            var explosionSeq = DOTween.Sequence();
            foreach (var exp in explosion)
            {
                // Join sprawia, ¿e wszystkie DOScale bêd¹ biec równolegle w tej sekwencji
                explosionSeq.Join(exp.DOScale(explosionEndScale, animationDuration).SetEase(Ease.OutBack));
            }

            // Dodaj sekwencjê eksplozji po zakoñczeniu ruchu o³ówków
            mainSeq.Append(explosionSeq);
        }

        mainSeq.Play();
    }
}
