using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding.Serialization.JsonFx;

public class Book : MonoBehaviour {
    //link to BookTable in Azure easytables
    public string _WebsiteURL = "http://infosys320.azurewebsites.net/tables/bookData?zumo-api-version=2.0.0";
    public UnityEngine.GameObject[] books;
    public GameObject myPrefab;
    // Use this for initialization
    void Start () {
        //Request.GET makes a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);
        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse)) { return; }
        //creates an array of the table in C#
        BookDetails[] Details = JsonReader.Deserialize<BookDetails[]>(jsonResponse);
        //creates a new book
        var newBook = (GameObject)Instantiate(myPrefab);

        foreach (BookDetails book in Details)
        {
            Debug.Log("Book Title:" + book.Title);
        }
        Debug.Log("Number of books in Table:" + Details.Length);
        //sets the text for title to the title in the table
        newBook.transform.Find("Title").GetComponent<TextMesh>().text = Details[0].Title;
        //sets the text for the author to the author in the table
        newBook.transform.Find("Author").GetComponent<TextMesh>().text = Details[0].Author;
    }

    public void PostBook() {
        BookDetails postbook = new BookDetails();

        postbook.Title = "TestBook";
        postbook.Author = "testAuthor";
        postbook.Publisher = "TestPublisher";

        string output = JsonWriter.Serialize(postbook);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
