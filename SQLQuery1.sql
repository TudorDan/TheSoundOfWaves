SELECT Courses.*, Subjects.Name, Documents.Name, Documents.Link FROM Catalogues
JOIN CourseCatalogue ON Catalogues.Id = CourseCatalogue.CatalogueId
JOIN Courses ON CourseCatalogue.CourseId = Courses.Id
JOIN Subjects ON Courses.SubjectId = Subjects.Id
JOIN Documents ON Courses.Id = Documents.CourseId
WHERE Catalogues.SchoolId = 1;