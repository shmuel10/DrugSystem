﻿using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriveQuickstart
{
    class Program
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/drive-dotnet-quickstart.json
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "Drive API .NET Quickstart";

        static void Main(string[] args)
        {
            UserCredential credential;
            credential = GetCredential();

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer() {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            string path = @"C:/Users/User/source/reposDrugSystem/DrugSystem/DrugSystem/Icons";
            string fullPath = @"";
           
           // if (System.IO.File.Exists(path))
          //  {
                fullPath = Path.GetFullPath(path);
          //  }
            
            UploadImg(fullPath, service);
            // ListFiles(service);
            Console.WriteLine("Done");
            Console.Read();
        }

        private static void UploadImg(string path, DriveService service)
        {
            var fileMetaData = new Google.Apis.Drive.v3.Data.File();
            fileMetaData.Name = Path.GetFileName(path);
            fileMetaData.MimeType = "image/jpeg/folder";
            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(path,System.IO.FileMode.Open))
            {
                request = service.Files.Create(fileMetaData, stream, "image/jpeg/folder");
                request.Fields = "id";
                
                request.Upload();
            }
            var file = request.ResponseBody;
            Console.WriteLine(file.Id);
        }

        private static void ListFiles(DriveService service)
        {
            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;
            Console.WriteLine("Files:");
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    Console.WriteLine("{0} ({1})", file.Name, file.Id);
                }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
        }

        private static UserCredential GetCredential()
        {
            UserCredential credential;
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
               // string credPath = "token.json";
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
        //        Console.WriteLine("Credential file saved to: " + credPath);
            }

            return credential;
        }
    }
}