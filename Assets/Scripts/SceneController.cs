using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
   
    public int gridRows = 2; 
    public int gridCols = 4;
    public float offsetX = 2f; 
    public float offsetY = 2.5f; 

    private int score;

    private MemoryCard firstRevealed;
    private MemoryCard secondRevealed;

   
    public bool canReveal => secondRevealed == null;

    [SerializeField] MemoryCard originalCard;
    [SerializeField] Sprite[] images;
    [SerializeField] TMP_Text scoreLabel;

    public void Restart()

    {

        SceneManager.LoadScene("SampleScene");

    }
    void Start()
    {
        Vector3 startPos = originalCard.transform.position;
        int numCards = gridRows * gridCols;
        int[] numbers = new int[numCards];

        if (images.Length < numCards / 2)
        {
            Debug.LogError("Not enough images for the number of cards!");
            return;
        }

        for (int i = 0; i < numCards / 2; i++)
        {
            numbers[i * 2] = i;
            numbers[i * 2 + 1] = i;
        }

        numbers = ShuffleArray(numbers);

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                
                MemoryCard card = Instantiate(originalCard);

                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);

                card.transform.SetParent(this.transform); 
            }
        }
    

}
    public void CardRevealed(MemoryCard card)
    {
        if(firstRevealed == null)
        {
            firstRevealed = card;
        }
        else
        {
            secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }
    private IEnumerator CheckMatch()
    {
        if(firstRevealed.Id == secondRevealed.Id)
        {
            score++;
            scoreLabel.text = $"Score: {score}";
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            firstRevealed.Unrevealed();
            secondRevealed.Unrevealed();
        }
        firstRevealed =null;
        secondRevealed =null;
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for(int i = 0;i< newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(0, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
