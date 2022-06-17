select emp.*,
iif((select (MAX(Salary) - emp.Salary) from Employee where [Rank] = emp.[Rank]) > 0,
(select convert(nvarchar(250), (MAX(Salary) - emp.Salary)) from Employee where [Rank] = emp.[Rank]), 'Max Salary') as SalaryDifference
from Employee emp 
order by emp.[Rank] asc, emp.Salary desc