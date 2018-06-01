namespace FormTypes

open System.Windows.Forms
open System.Drawing
open SQLDataLayer
open System.Data

type SQLEditorForm() as a = 
        inherit Form()
        let get_all_rows =
            let dt = new DataTable()
            dt.Columns.Add("ID") |> ignore
            dt.Columns.Add("MSG") |> ignore
            for i in SQL.gettable do
                let dr = dt.NewRow();
                dr.[0] <- i.ID
                dr.[1] <- i.MSG
                dt.Rows.Add(dr) |> ignore
            dt
        let lbl_returnsize = 
            let temp = new Label()
            temp.Text <- "SHOW:"
            temp.Size <- new Size(50,20)
            temp.Location <- new Point(525,55)
            temp
        let ddl_returnsize =
            let temp = new ComboBox()
            temp.Size <- new Size(50,25)
            temp.Location <- new Point(575,50)
            temp.Items.AddRange([|"5"; "10"; "25"; "50"; "100"; "300"|])
            temp
        let data_gridview = 
            let temp = new DataGridView()
            temp.Location <- new Point(25,75)
            temp.Size <- new Size(600,350)
            temp.DataSource <- get_all_rows
            temp
        let txt_search = 
            let temp = new TextBox()
            temp.Location <- new Point(25,50)
            temp.Size <- new Size(300,25)
            temp
        let btn_search = 
            let temp = new Button()
            temp.Location <- new Point(325,50)
            temp.Size <- new Size(75,20)
            temp.BackColor <- Color.Black
            temp.ForeColor <- Color.Cyan
            temp.Text <- "SEARCH"
            temp.Name <- "btn_search"
            temp
        let btn_new = 
            let temp = new Button()
            temp.Location <- new Point(350,430)
            temp.Size <- new Size(75,20)
            temp.BackColor <- Color.Cyan
            temp.ForeColor <- Color.Black
            temp.Text <- "NEW"
            temp
        let btn_edit = 
            let temp = new Button()
            temp.Location <- new Point(450,430)
            temp.Size <- new Size(75,20)
            temp.BackColor <- Color.Blue
            temp.ForeColor <- Color.White
            temp.Text <- "EDIT"
            temp
        let btn_delete = 
            let temp = new Button()
            temp.Location <- new Point(550,430)
            temp.Size <- new Size(75,20)
            temp.BackColor <- Color.Red
            temp.ForeColor <- Color.White
            temp.Text <- "DELETE"
            temp
        let initialize = 
            do a.Text <- "F# SQL Editor"
            do a.Size <- new Size(665, 500)
            do a.FormBorderStyle <- FormBorderStyle.FixedSingle
            do a.BackColor <- Color.LightPink
            do a.Controls.Add(lbl_returnsize)
            do a.Controls.Add(ddl_returnsize)
            do a.Controls.Add(data_gridview)
            do a.Controls.Add(txt_search)
            do a.Controls.Add(btn_search)
            do a.Controls.Add(btn_new)
            do a.Controls.Add(btn_edit)
            do a.Controls.Add(btn_delete)
        do initialize

        
