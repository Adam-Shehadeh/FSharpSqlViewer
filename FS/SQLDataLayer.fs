module SQL 
    open System
    open System.Data.SqlClient
    open System.Collections.Generic
    open System.Windows.Forms
    open Error_Output


    let conn = new SqlConnection("Data Source=den1.mssql3.gear.host;Initial Catalog=dbroyann;User ID=dbroyann;Password=Royann317!")
    type RowType =  {
        ID: int 
        MSG: string
    }

    let gettable = seq {
        let cmd = new SqlCommand("SELECT * FROM [dbroyann].[dbo].[tbl_MAIN]", conn)
        conn.Open()
        use reader = cmd.ExecuteReader()
        while (reader.Read()) do
            yield{ ID = unbox (reader.["ID"]); MSG = unbox (reader.["MSG"])}
        conn.Close()
    }

    let updatetable (data : seq<string>) = 
        let mutable sqlstr =    "USE [dbroyann]
        TRUNCATE TABLE tbl_MAIN
        DBCC CHECKIDENT ('tbl_MAIN', RESEED, 1)
        "
        for i in data do
            if i <> "" && not <| String.IsNullOrEmpty(i) then
                let delim_i = i.Replace("'", "''"); //replaces ' with '' to delimit for SQL insertion
                sqlstr <- sqlstr + "INSERT [dbo].[tbl_MAIN] ([MSG]) VALUES ('" + delim_i + "')
                "
        try
            let cmd = new SqlCommand(sqlstr, conn)
            conn.Open()
            let rows_aff = cmd.ExecuteNonQuery()
            conn.Close()
        
            if rows_aff > 0 then
                "Successfully updated table!"
            else
                "Could not update table."
        with
            | ex -> 
                output_err(ex)
                ex.Message.ToString()
        


