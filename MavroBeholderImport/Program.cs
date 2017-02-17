using FileHelpers;
using MavroBeholderImport.DataAccess;
using MavroBeholderImport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;

namespace MavroBeholderImport
{
    class Program
    {
        private static string _sourceFileName;
        private const int CreatedUserId = 1;

        static void Main(string[] args)
        {

            do
            {
                Console.Write("Enter file path or 'exit': ");
                _sourceFileName = Console.ReadLine();

                if (_sourceFileName != "exit")
                {
                    if (!File.Exists(_sourceFileName))
                    {
                        Console.WriteLine("File does not exist ");
                        Console.Write("Enter file path or 'exit': ");
                        _sourceFileName = Console.ReadLine();
                    }
                }
                else
                {
                    break;
                }

                Console.WriteLine($"Reading file path {_sourceFileName}");

                ExtractLoadChapterPublications();
                ExtractLoadPersonPublications();
                ExtractLoadWebsitePublications();


            } while (_sourceFileName != "exit");

            Console.WriteLine("Finished ");
            Console.Write("Press Any Key ");
            Console.ReadKey();
        }

        private static void ExtractLoadWebsitePublications()
        {
            var results = GetDataFileResults("WEBSITE");

            using (var db = new AppContext())
            {
                foreach (var record in results.ToList())
                {
                    var beholderRecord = db.MediaWebsiteEGroups.Find(Convert.ToInt32(record.Id));
                    if (beholderRecord == null) continue;
                    Console.WriteLine("Creating item for WebSite: {0}: Id: {1}", beholderRecord.Name ?? "Unknown", beholderRecord.Id);
                    using (var client = new WebClient())
                    {
                        byte[] buffer = client.DownloadData(record.Url);

                        var context = new MediaWebsiteEGroupContext()
                        {
                            MediaWebsiteEGroupId = beholderRecord.Id,
                            ContextText = buffer,
                            MimeTypeId = 7,
                            DocumentExtension = ".pdf",
                            FileStreamID = Guid.NewGuid(),
                            FileName = "MavroImport-Website-" + beholderRecord.Name + ".pdf",
                        };
                        db.MediaWebsiteEGroupContexts.Add(context);
                        db.SaveChanges();
                    }
                }
            }
        }

        private static void ExtractLoadPersonPublications()
        {
            var results = GetDataFileResults("PERSON");

            using (var db = new AppContext())
            {
                foreach (var record in results.ToList())
                {
                    var id = Convert.ToInt32(record.Id);
                    var beholderRecord = db.BeholderPeople.Include("CommonPerson").FirstOrDefault(p => p.Id == id);
                    if (beholderRecord == null) continue;

                    Console.WriteLine("Creating item for Person: {0}: BeholderId: {1}", beholderRecord.CommonPerson.FullName, beholderRecord.Id);

                    using (var client = new WebClient())
                    {
                        byte[] buffer = client.DownloadData(record.Url);

                        var rel = new PersonMediaPublishedRel()
                        {

                            PersonId = beholderRecord.Id,
                            RelationshipTypeId = 99,
                            MediaPublished = new MediaPublished()
                            {
                                MediaTypeId = 4,
                                ConfidentialityTypeId = 4,
                                DateCreated = DateTime.Now,
                                DateModified = DateTime.Now,
                                CreatedUserId = CreatedUserId,
                                Name = "MavroImport-Person-" + beholderRecord.CommonPerson.LName
                            }
                        };
                        db.PersonMediaPublishedRels.AddOrUpdate(rel);
                        db.SaveChanges();

                        var context = new MediaPublishedContext()
                        {
                            ContextText = buffer,
                            MimeTypeId = 7,
                            DocumentExtension = ".pdf",
                            FileStreamID = Guid.NewGuid(),
                            FileName = "MavroImport-Person-" + beholderRecord.CommonPerson.FullName + ".pdf",
                            MediaPublishedId = rel.MediaPublishedId
                        };
                        db.MediaPublishedContexts.Add(context);
                        db.SaveChanges();


                    }
                }
            }
        }

        public static void ExtractLoadChapterPublications()
        {
            var results = GetDataFileResults("CHAPTER");

            using (var db = new AppContext())
            {
                foreach (var record in results.ToList())
                {
                    var beholderRecord = db.Chapters.Find(Convert.ToInt32(record.Id));

                    if (beholderRecord == null) continue;

                    Console.WriteLine("Creating publication for chapter: {0}: Id: {1}", beholderRecord.ChapterName, beholderRecord.Id);
                    using (var client = new WebClient())
                    {
                        byte[] buffer = client.DownloadData(record.Url);

                        var rel = new ChapterMediaPublishedRel()
                        {
                            ChapterId = beholderRecord.Id,
                            RelationshipTypeId = 99,
                            MediaPublished = new MediaPublished()
                            {
                                MediaTypeId = 4,
                                ConfidentialityTypeId = 4,
                                DateCreated = DateTime.Now,
                                DateModified = DateTime.Now,
                                CreatedUserId = CreatedUserId,
                                Name = "MavroImport-Chapter-" + beholderRecord.ChapterName
                            }
                        };
                        db.ChapterMediaPublishedRels.AddOrUpdate(rel);
                        db.SaveChanges();

                        var context = new MediaPublishedContext()
                        {
                            ContextText = buffer,
                            MimeTypeId = 7,
                            DocumentExtension = ".pdf",
                            FileStreamID = Guid.NewGuid(),
                            FileName = "MavroImport-Chapter-" + beholderRecord.ChapterName + ".pdf",
                            MediaPublishedId = rel.MediaPublishedId
                        };
                        db.MediaPublishedContexts.Add(context);
                        db.SaveChanges();

                        Console.WriteLine("Created publication {0}", rel.MediaPublished);
                    }
                }
            }
        }

        private static IEnumerable<MavroRecord> GetDataFileResults(string recordType)
        {
            var engine = new FileHelperEngine<MavroRecord>();
            var results = engine.ReadFile(@"C:\temp\beholderArchiveUrl.csv").Where(r => r.RecordType == recordType);
            return results;
        }

    }
}
