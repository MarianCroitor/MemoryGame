using UnityEngine;
using System.Collections;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] GameObject cardBack;
    private SceneController controller;
    private Animator animator;

    private int _id;
    public int Id { get { return _id; } }

    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    private void Start()
    {
        controller = Object.FindFirstObjectByType<SceneController>();
        animator = GetComponent<Animator>();
        if (controller == null)
        {
            Debug.LogError("SceneController not found");
        }
       
        StartCoroutine(StartFlip());
    }

    public void OnMouseDown()
    {
        if (controller != null && cardBack.activeSelf && controller.canReveal)
        {
            cardBack.SetActive(false);
            animator.SetTrigger("Open");
            controller.CardRevealed(this);
        }
    }

    public void Unrevealed()
    {
        animator.SetTrigger("Close");
        StartCoroutine(Reenable());
    }

    private IEnumerator Reenable()
    {
        yield return new WaitForSeconds(0.25f);
        cardBack.SetActive(true);
    }

    private IEnumerator StartFlip()
    {
        cardBack.SetActive(false);
        animator.SetTrigger("Open");
        yield return new WaitForSeconds(3f);
        animator.SetTrigger("Close");
        yield return new WaitForSeconds(0.25f);
        cardBack.SetActive(true);
    }
}
