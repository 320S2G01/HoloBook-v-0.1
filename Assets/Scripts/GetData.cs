using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class GetData : MonoBehaviour {
    public string bookData = @"http://infosys320.azurewebsites.net/tables/bookData?zumo-api-version=2.0.0";
    BookDetails[] books;
    bool _fetchedItems = false;

    // Use this for initialization
    void Start () {
        WWW www = new WWW(bookData);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        foreach (BookDetails book in books)
        {
            Debug.Log("Book Title:" + book.Title);
        }


        // check for errors
        if (www.error == null)
        {
            var dataString = JsonHelper.AppendWrapper(www.text);
            books = JsonHelper.FromJson<BookDetails>(dataString);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
        

    // Update is called once per frame
    void Update () {

	}
}
