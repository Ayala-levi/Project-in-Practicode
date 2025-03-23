### פרויקט 3 | אפליקציית ניהול משימות ב-Minimal API
### תיאור הפרויקט
אפליקציית Fullstack לניהול משימות, המפותחת באמצעות Minimal API ב-.NET. הפרויקט כולל פיתוח של שרת API ב-Minimal API, אפליקציית לקוח ב-React ואינטגרציה עם מסד נתונים MySQL. האפליקציה מאפשרת למשתמשים ליצור, לערוך, ולנהל רשימת משימות אישית.

### טכנולוגיות בשימוש
- **צד שרת:** .NET Minimal API
- **מסד נתונים:** MySQL
- **צד לקוח:** React
- **כלי פיתוח:** Entity Framework Core, Dotnet CLI,Visual Studio, Visual Studio Code, Axios
### תכונות עיקריות
- **יצירת משימות:** הוספת משימות חדשות לרשימה.
- **עדכון משימות:** עריכת פרטי משימות קיימות.
- **מחיקת משימות:** הסרת משימות מהרשימה.
- **שליפת משימות:** הצגת רשימת כל המשימות.
### התקנה והרצה
שיבוט הפרויקט:
```bash
git clone https://github.com/Ayala-levi/Project-in-Practicode
```
צד שרת (Minimal API)
1. הגדרת מסד נתונים:
   - התקינו MySQL ו-MySQL Workbench.
   - צרו טבלה בשם Items עם השדות Id, Name, ו-IsComplete.
   - הגדירו את Connection String בקובץ appsettings.json.
2. הרצת השרת:
```bash
dotnet watch run
```
### צד לקוח (React)
1. התקנת תלויות:

```bash
npm install
```
2. הגדרת כתובת API:
  עדכנו את ה-route ב-service.js לכתובת ה-API שלכם.
4. הרצת הלקוח:

```bash
npm start
```

### הערות נוספות
* האפליקציה משתמשת ב-Entity Framework Core לגישה למסד הנתונים.
* ה-API מוגדר עם CORS כדי לאפשר קריאות מאפליקציית הלקוח.
* ה-API כולל Swagger לתיעוד וניסיון של נקודות הקצה.
* נעשה שימוש ב-Axios לביצוע קריאות HTTP מאפליקציית הלקוח.
