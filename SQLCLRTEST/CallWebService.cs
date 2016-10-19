using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Net;
using System.IO;
using System.Text;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void CallWebService ()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.webserviceX.NET//globalweather.asmx//GetCitiesByCountry?CountryName=Sri Lanka");
       
        request.Method = "GET";
        request.ContentLength = 0;
        request.Credentials = CredentialCache.DefaultCredentials;
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();        
        Stream receiveStream = response.GetResponseStream();   
        // Pipes the stream to a higher level stream reader with the required encoding format. 
        StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);    

        Console.WriteLine("Response stream received.");
        System.IO.File.WriteAllText("d://response.txt", readStream.ReadToEnd());
        
        response.Close();
        readStream.Close();
    }
}
