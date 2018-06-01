namespace SQLDataLayer

open System
open System.Data.SqlClient



module SQL =
    let conn = new SqlConnection("Data Source=den1.mssql3.gear.host;Initial Catalog=dbroyann;User ID=dbroyann;Password=Royann317!")
    type RowType =  {
        ID: int 
        MSG: string
    }

    let gettable = seq {
        let _conn = conn
        let cmd = new SqlCommand("SELECT * FROM [dbroyann].[dbo].[tbl_MAIN]", _conn)
        _conn.Open()
        use reader = cmd.ExecuteReader()
        while (reader.Read()) do
            yield{ ID = unbox (reader.["ID"]); MSG = unbox (reader.["MSG"])}
        _conn.Close()
    }
    let exec_test = 
        for i in gettable do
            let line = printfn "ID: %i MSG: %s" i.ID i.MSG
            line



