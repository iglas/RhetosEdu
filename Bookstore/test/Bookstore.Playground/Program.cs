using Rhetos;
using Rhetos.Logging;
using Rhetos.Utilities;
using System;
using System.Collections.Generic;
using Rhetos.Dom.DefaultConcepts;
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

                

                /*                            //DAY2

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
                

                //DAY 2  */

                //DAY3
                var filterParametar = new Bookstore.LongBooks();
                var q = repository.Bookstore.Book.Query(filterParametar, typeof(Bookstore.LongBooks));
                

                var newForeignBook = new ForeignBook() { ID = Guid.Parse("fb7237c7-aa8f-4c8c-8bee-589e32c8bee3"), OriginalLanguage="HR"};
                repository.Bookstore.ForeignBook.Save(new List<ForeignBook> { newForeignBook }, null, null);
                //repository.Bookstore.Book.Insert(newBook);

                ConsoleDump.Extensions.Dump(q);

                Console.WriteLine(q.ToString());

                container.CommitChanges();
                Console.ReadLine();
                // <<<< Copy-paste the example code here >>>>
            }
        }
    }
}
