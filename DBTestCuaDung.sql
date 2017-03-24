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
 where p.ProductID='' and p.StoreID='1'

