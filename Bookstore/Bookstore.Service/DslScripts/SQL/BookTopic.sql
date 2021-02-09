SELECT b.Id Id, count(bt.ID) TopicCount
from Bookstore.Book b
LEFT OUTER join Bookstore.BookTopic bt ON bt.BookID = b.ID
group by b.ID