using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class TweenGroupAlpha : MonoBehaviour
{
    private IEnumerator m_currentTween = null;
    private CanvasGroup m_target;
    private float m_duration;
    private float m_targetValue;
    private float m_delay;
    private float m_initialValue;
    private float m_lerpValue = 0;
    private UnityEvent m_onEnd;
    private UnityEvent m_onBegin;

    public static void Begin( CanvasGroup _target, float _duration, float _value, float _delay = 0, UnityEvent _onBegin = null, UnityEvent _onEnd = null)
    {
        if ( _target.GetComponent<TweenGroupAlpha>() != null )
            Destroy(_target.GetComponent<TweenGroupAlpha>());

        TweenGroupAlpha tweenAlphaComponent = _target.gameObject.AddComponent<TweenGroupAlpha>();
        tweenAlphaComponent.Init(_target, _duration, _value, _delay, _onBegin, _onEnd);
    }

    public void Init( CanvasGroup _target, float _duration, float _value, float _delay, UnityEvent _onBegin, UnityEvent _onEnd )
    {
        m_target = _target;
        m_duration = _duration;
        m_targetValue = _value;
        m_delay = _delay;
        m_onBegin = m_onBegin;
        m_onEnd = m_onEnd;

        if ( m_currentTween != null )
        {
            StopCoroutine(m_currentTween);
            m_currentTween = null;
        }

        m_currentTween = TweenRoutine();
        StartCoroutine(m_currentTween);
    }

    private IEnumerator TweenRoutine()
    {
        yield return new WaitForSeconds(m_delay);

        float currentAlpha = m_target.alpha;
        m_initialValue = m_target.alpha;
        m_lerpValue = 0;

        if ( m_onBegin != null )
            m_onBegin.Invoke();

        while ( currentAlpha != m_targetValue )
        {
            float valueToSet = Mathf.Lerp(m_initialValue, m_targetValue, m_lerpValue);
            m_target.alpha = valueToSet;
            currentAlpha = valueToSet;
            m_lerpValue += ( Time.deltaTime / m_duration );
            yield return null;
        }

        currentAlpha = m_targetValue;
        m_target.alpha = m_targetValue;
        m_lerpValue = 1;

        if ( m_onEnd != null )
            m_onEnd.Invoke();
    }
}
