using Rhetos;
using Rhetos.Logging;
using Rhetos.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            string applicationFolder = @"..\..\..\..\Bookstore.Service\obj\Rhetos";
            var directory = System.IO.Directory.GetFiles(applicationFolder);
            ConsoleLogger.MinLevel = EventType.Info; // Use EventType.Trace for more detailed log.

            using (var container = ProcessContainer.CreateTransactionScopeContainer(applicationFolder))
            {
                
                var context = container.Resolve<Common.ExecutionContext>();
                var repository = context.Repository;


                //repository.Bookstore.Book.Load()

                //1
                foreach (var book in  repository.Bookstore.Book.Load())
                {
                    List<Guid> ids = new List<Guid>();

                    string authorName = string.Empty;
                    if (book.AuthorID.HasValue)
                    {
                        ids.Add(book.AuthorID.Value);
                        
                        var author = repository.Bookstore.Person.Load(ids);//Obsolete?
                        authorName = author.FirstOrDefault()?.Name;
                    }

                    Console.WriteLine(book.Title + "\t\t\t\t" +  authorName);                                        
                }

                Console.WriteLine();
                Console.WriteLine("------------------------");
                Console.WriteLine();

                //2
                var q = repository.Bookstore.Book.Query().Select(x => new { x.Title, x.NumberOfPages, x.Author.Name });
                ConsoleDump.Extensions.Dump(q);

                Console.WriteLine();
                Console.WriteLine("------------------------");
                Console.WriteLine();

                //3
                Console.WriteLine(q.ToString());


                //4
                repository.Bookstore.GenerateBooks.Execute(new GenerateBooks() { NumberOfBooks = 2, Title = "Novele" });

                //repository.Bookstore.Insert5Books.Execute(null);
                //repository.Bookstore.CreatePrincipal.Execute(new CreatePrincipal() {  Name = "Ivan Glas" });//ID ne radi jer u .rhe skripti tip podataka je Guid, pa ne radi konverzija u Guid?
                container.CommitChanges();
                Console.ReadLine();
                // <<<< Copy-paste the example code here >>>>
            }
        }
    }
}
