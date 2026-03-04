-- إنشاء قاعدة البيانات 
CREATE DATABASE StudentDB;
GO
USE StudentDB;

--  إنشاء الجدول الخاص بتخزين بيانات الطلبة
CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,      
    Age INT,                          
    Grade NVARCHAR(50)               
);
GO

-- إنشاء الأمر الخاص بعرض الطلاب 
CREATE VIEW ViewStudents AS
SELECT Name, Age, Grade FROM Students;
GO

-- إنشاء الأمر الخااص بإضافة طالب
CREATE PROCEDURE sp_AddStudent
    @Name NVARCHAR(100),
    @Age INT,
    @Grade NVARCHAR(50)
AS
BEGIN
    INSERT INTO Students (Name, Age, Grade)
    VALUES (@Name, @Age, @Grade);
END;
GO
SELECT * FROM Students;
