--dbfirst
start dotnet ef dbcontext scaffold "server=localhost;uid=root;pwd=123;port=3306;database=bems;" "MySql.Data.EntityFrameworkCore" -o EF -f

--code first
dotnet ef migrations add InitialCreate --project BEMS.Web
dotnet ef database update --project BEMS.Web

add-migration newts
update-database

add-migration new -c BEMSContext
update-database -c BEMSContext