select b.BillID as N'Mã chứng từ',b.CreateDate as N'Thời gian',
bd.Quantity as N'SL Sản phẩm',p.Name as N'Tên Sản Phẩm'
,p.Price as N'Giá Nhập',p.SellPrice as N'Giá Bán',(p.SellPrice-p.Price)*bd.Quantity as N'Doanh Thu'
from Bills b join BillDetails bd
on b.BillID=bd.BillID join Products p
on p.ProductID=bd.ProductID

select b.BillID as N'Mã chứng từ',b.CreateDate as N'Thời gian',
bd.Quantity as N'SL Sản phẩm',p.Name as N'Tên Sản Phẩm'
,p.Price as N'Giá Nhập',p.SellPrice as N'Giá Bán',(p.SellPrice-p.Price)*bd.Quantity as N'Doanh Thu'
from Bills b join BillDetails bd
on b.BillID=bd.BillID join Products p
on p.ProductID=bd.ProductID where b.StaffID = 2

select 'TA' = sum((p.SellPrice-p.Price)*bd.Quantity) from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID

select p.ProductID,p.Name,p.Description,p.StoreID,p.Unit,pu.UnitName,p.Status from
Products p join ProductUnit pu on p.ProductID =pu.ProductID
where p.ProductID like '%1%' and p.StoreID like '%%'

select *from Staffs
select *from Products
select *from Bills
select s.Name,s.StoreID from Stores s join Staffs st
on s.StoreID=st.StoreID where st.StaffID= '2'
group by s.Name,s.StoreID

select s.StaffID,s.Name,s.Address,s.Phone,SUM ((bd.SellPrice - bd.Price)*bd.Quantity) as 'Income Total' from Staffs s join Bills b 
on s.StaffID=b.StaffID join BillDetails bd
on b.BillID=bd.BillID
where MONTH(b.CreateDate) = '3' and s.StaffID like '%%'
group by s.StaffID,s.Name,s.Address,s.Phone

select s.StoreID,s.Name from Stores s join Staffs st
on s.StoreID=st.StoreID join Bills b
on st.StaffID=b.StaffID join BillDetails bd
on b.BillID=bd.BillID
where MONTH(b.CreateDate) = '3' and s.StoreID like '%%'
group by s.StoreID,s.Name

select * from Bills
select * from BillDetails
select * from Bills

select b.BillID as N'Voucher code',b.CreateDate as N'Create Date',bd.Quantity,p.Name as N'Product Name',p.Price,p.SellPrice as N'Sell Price',(p.SellPrice-p.Price)*bd.Quantity as N'Revenue' from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID

select 'TA' = sum((p.SellPrice-p.Price)*bd.Quantity) from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID


