using System.Collections;
using UnityEngine;

public class GhostEffect : MonoBehaviour
{
    [Header("Stats")]
    public float DelayTime = 0.05f;
    public float ExistTime = 0.25f;
    public float FadeOutTime = 0.25f;
    private float delayTimeCounter;

    [Header("Color")]
    public Color GhostColor = Color.blue;

    [Header("Components")]
    [SerializeField] private GameObject _ghost;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _ghost = CreateGhostObject();

        delayTimeCounter = DelayTime;
    }

    private GameObject CreateGhostObject()
    {
        // create ghost game object
        GameObject ghost = new GameObject();
        ghost.name = "Ghost Trail";

        // adjust sprite color and sorting order
        SpriteRenderer sr = ghost.AddComponent<SpriteRenderer>();
        sr.sortingOrder = _spriteRenderer.sortingOrder - 1;
        return ghost;
    }

    private void Update()
    {
        delayTimeCounter -= Time.deltaTime;
        if (delayTimeCounter < 0)
        {
            // instantiate Ghost Prefab
            GameObject ghost = Instantiate(_ghost, transform.position, transform.rotation);
            ghost.GetComponent<SpriteRenderer>().sprite = _spriteRenderer.sprite; // pender sprite
            ghost.GetComponent<SpriteRenderer>().flipX = _spriteRenderer.flipX; // flip sprite 
            ghost.GetComponent<SpriteRenderer>().color = GhostColor;

            // start fade out
            StartCoroutine(FadeOut(ghost));

            // reset timer
            delayTimeCounter = DelayTime;
        }
    }

    private IEnumerator FadeOut(GameObject ghost)
    {
        SpriteRenderer ghostSpriteRenderer = ghost.GetComponent<SpriteRenderer>();
        Color ghostColor = ghostSpriteRenderer.color;

        // exist time for ghost effect
        float timer = 0f;
        while (timer < ExistTime)
        {
            timer += Time.deltaTime;

            yield return null;
        }

        // start fade out ghost effect and destroy it
        timer = 0f;
        while (timer < FadeOutTime)
        {
            float alpha = Mathf.Lerp(ghostColor.a, 0f, timer / FadeOutTime);
            ghostColor.a = alpha;

            ghostSpriteRenderer.color = ghostColor;

            timer += Time.deltaTime;

            yield return null;
        }

        Destroy(ghost);
    }

    public void Play(float time)
    {
        StartCoroutine(CreateGhost(time));
    }

    private IEnumerator CreateGhost(float time)
    {
        this.enabled = true;
        yield return new WaitForSeconds(time);
        this.enabled = false;
    }
}