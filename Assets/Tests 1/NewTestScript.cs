using System.Collections;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class ManagePuzzleGameTests
{
    [UnityTest]
    public IEnumerator CreatePlaceholders_Test()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Puzzle 1");
        yield return new WaitForSeconds(1f);

        GameObject Placeholder = GameObject.Find("PH1");
        
        Assert.IsNotNull(Placeholder, "This is null");
    }

    [UnityTest]
    public IEnumerator CreatePieces_Test()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Puzzle 1");
        yield return new WaitForSeconds(1f);

        GameObject Pieces = GameObject.Find("Piece1");
        
        Assert.IsNotNull(Pieces, "This is null");
    }

    [UnityTest]
    public IEnumerator ShufflePieces_Test()
    {
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Puzzle 1");
        yield return new WaitForSeconds(4f);

        GameObject Shuffle = GameObject.Find("managePuzzleGame");
        
        Assert.IsNotNull(Shuffle, "This is null");

        bool boolShuffle = Shuffle.GetComponent<ManagePuzzleGame>().cardsShuffled;
    }
}