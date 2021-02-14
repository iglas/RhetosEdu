select b.Title, b.Code, g.Name Genre, g.Fiction
from Bookstore.Book b
LEFT OUTER JOIN Bookstore.Genre g on b.GenreID = g.ID