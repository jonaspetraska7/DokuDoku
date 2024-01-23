
# ![image](https://github.com/jonaspetraska7/DokuDoku/assets/60759096/ede19124-ed73-478d-8caa-e9dccd7c3028) DokuDoku
---
.NET PDF, WORD, EXCEL Library. Easy to use, free forever.

DokuDoku is using Migradoc Library to make all of this happen. MIT License. Fully Open source.

Documentation for the and useful resources for the Migradoc PDF library : 

- https://github.com/empira/pdfsharp.Samples
- https://www.linkedin.com/pulse/pdf-generation-using-migradoc-arnoud-van-bokkem

---
# Usage

```
public MemoryStream CreatePdf()
    {
        var MyObject = new
        {
            Id = "101",
            FirstName = "John",
            LastName = "Johnson",
            ComplexProperty = new
            {
                Country = "LTU",
                Address = "Main str. 841, Vilnius",
            }
        };
        
        MemoryStream pdf = Doku.PDF.Generate("MyPdf", pdf =>
        {
            pdf.AddTable("Table1", t =>
            {
                t.Config(true, 200, 200);
                t.Property("Identification No.", MyObject.Id);
                t.Property("First name", MyObject.FirstName);
                t.Property("LastName", MyObject.LastName);
                t.Property("Current Location : ", t =>
                {
                    t.Config(false, 100, 100);
                    t.Property("Country :", MyObject.ComplexProperty.Country);
                    t.Property("Address", MyObject.ComplexProperty.Address);
                });
            }, MyObject != null);
            pdf.AddTable("MyHorizontalTable", t =>
            {
                t.Config(true, 100, 100, 100);
                t.Property("Id", "FirstName", "LastName");
                for (int i = 0; i < 7; i++)
                {
                    t.Property(MyObject.Id, MyObject.FirstName, MyObject.LastName);
                }
            });
        });

        return pdf;
    }
```

How it looks like : 
![image](https://github.com/jonaspetraska7/DokuDoku/assets/60759096/234ec13a-8f5c-4d8d-aabd-862cc7f693c1)

