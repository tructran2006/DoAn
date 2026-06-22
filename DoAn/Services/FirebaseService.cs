using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;

namespace DoAn.Services
{
    public class FirebaseService
    {
        private readonly FirestoreDb _db;

        public FirebaseService()
        {
            // Lấy credential từ FirebaseApp đã khởi tạo ở Program.cs
            var credential = FirebaseApp.DefaultInstance.Options.Credential;

            // Khởi tạo Firestore với credential này
            var builder = new FirestoreClientBuilder
            {
                Credential = credential
            };

            _db = FirestoreDb.Create("doan-b99f4", builder.Build());
        }

        public async Task<List<Dictionary<string, object>>> GetPosts()
        {
            Query query = _db.Collection("Posts");
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            var list = new List<Dictionary<string, object>>();
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                list.Add(documentSnapshot.ToDictionary());
            }
            return list;
        }
    }
}