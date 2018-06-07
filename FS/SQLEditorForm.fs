namespace FormTypes

open System.Windows.Forms
open System.Drawing
open SQL
open System.Data
open System
open System.Drawing
open Error_Output

type frm_txt() as a = 
    inherit Form()
    let txt_box =
        let temp = new TextBox()
        temp.Size <- new Size(665,500)
        temp.Location <- new Point(0,0)
        temp.Multiline <- true
        temp
    let initialize = 
        do a.Text <- "F# display"
        do a.Size <- new Size(665, 500)
        do a.FormBorderStyle <- FormBorderStyle.FixedSingle
        do a.BackColor <- Color.LightPink
        do a.Controls.Add(txt_box)
    member this.change_txt (text : string) =
        do txt_box.Text <- text

type SQLEditorForm() as a = 
    inherit Form()
    let get_all_rows =
        try
            let dt = new DataTable()
            //dt.Columns.Add("ID") |> ignore
            dt.Columns.Add("MSG") |> ignore
            for i in SQL.gettable do
                let dr = dt.NewRow();
                dr.[0] <- i.MSG
                dt.Rows.Add(dr) |> ignore
            dt
        with 
            | ex -> 
                output_err(ex)
                new DataTable()
    let data_gridview = 
        let temp = new DataGridView()
        temp.Location <- new Point(25,25)
        temp.Size <- new Size(600,400)
        temp.DataSource <- get_all_rows
        temp
    let btn_save = 
        let temp = new Button()
        temp.Location <- new Point(550,430)
        temp.Size <- new Size(75,25)
        temp.BackColor <- Color.Cyan
        temp.ForeColor <- Color.Black
        temp.FlatStyle <- FlatStyle.Flat
        temp.FlatAppearance.BorderColor <- Color.Black
        temp.FlatAppearance.BorderSize <- 2
        temp.Text <- "SAVE"
        temp.Name <- "btnSave"
        temp
    let initialize = 
        do
            a.Text <- "F# SQL Editor"
            a.Size <- new Size(665, 500)
            a.FormBorderStyle <- FormBorderStyle.FixedSingle
            a.MaximizeBox <- false
            a.BackColor <- Color.Azure
            a.Controls.Add(data_gridview)
            a.Controls.Add(btn_save)
            a.Icon <- new Icon("cassette_tape.ico")
        btn_save.Click.Add(fun _ -> 
            try
                let rows = seq { for r in 0 .. data_gridview.RowCount - 2 -> data_gridview.Rows.[r].Cells.["MSG"].Value.ToString() }
                let frm = new frm_txt()
                MessageBox.Show(SQL.updatetable(rows).ToString()) |> ignore
                data_gridview.DataSource <- null
                data_gridview.DataSource <- get_all_rows
                data_gridview.Columns.[0].Width <- 535
            with 
                | ex -> output_err(ex) |> ignore
            )
        a.Load.Add(fun _ ->
            try
                data_gridview.Columns.[0].Width <- 535
            with 
                | ex -> output_err(ex) |> ignore
            )
    do initialize




        
