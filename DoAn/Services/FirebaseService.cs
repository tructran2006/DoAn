using FirebaseAdmin;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;

namespace DoAn.Services;

public class FirebaseService
{
    public FirestoreDb Db { get; }

    public FirebaseService()
    {
        var credential = FirebaseApp.DefaultInstance.Options.Credential;

        var builder = new FirestoreClientBuilder
        {
            Credential = credential
        };

        Db = FirestoreDb.Create(
            "doan-b99f4",
            builder.Build());
    }
}