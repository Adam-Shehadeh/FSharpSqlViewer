namespace FormExtension

open System
open System.Drawing
open System.Windows.Forms
open SQLDataLayer

module FormExecutor =
    open System.Data

    type MyForm() as a = 
        inherit Form(Width = 200, Height = 200)
        let lbl = new Label(Top = 25, Left = 25, Width = 100, Height = 25, TextAlign = ContentAlignment.MiddleCenter)
        let btn = new Button(Top = 75, Left = 25, Width = 100, Height = 25, Text = "Click!")
        do a.Controls.Add(lbl)
        do a.Controls.Add(btn)
        do btn.Click.Add(fun m ->
            lbl.Text <- "Hello World!")
        member this.SetLabel txt = 
            lbl.Text <- txt

    let HELLO_WORLD = new MyForm(Text = "F#")

    let START_FORM = 
        let sign_click (sender, evtArgs) =
            1
        let lbl1 = 
            let temp = new Label()
            temp.Size <- new System.Drawing.Size(100,25)
            temp.Text <- "Server:"
            temp.AutoSize <- true
            temp.Location <- new Drawing.Point(25,25)
            temp
        let lbl2 = 
            let temp = new Label()
            temp.Size <- new System.Drawing.Size(100,25)
            temp.Text <- "Database:"
            temp.AutoSize <- true
            temp.Location <- new Drawing.Point(25,50)
            temp
        let lbl3 = 
            let temp = new Label()
            temp.Size <- new System.Drawing.Size(100,25)
            temp.Text <- "(SQL)Username:"
            temp.AutoSize <- true
            temp.Location <- new Drawing.Point(25,75)
            temp
        let lbl4 = 
            let temp = new Label()
            temp.Size <- new System.Drawing.Size(100,25)
            temp.Text <- "Password:"
            temp.AutoSize <- true
            temp.Location <- new Drawing.Point(25,100)
            temp
        let txt1 =
            let temp = new TextBox()
            temp.Size <- new System.Drawing.Size(200,25)
            temp.Location <- new System.Drawing.Point(125,25)
            temp
        let txt2 =
            let temp = new TextBox()
            temp.Size <- new System.Drawing.Size(200,25)
            temp.Location <- new System.Drawing.Point(125,50)
            temp
        let txt3 =
            let temp = new TextBox()
            temp.Size <- new System.Drawing.Size(200,25)
            temp.Location <- new System.Drawing.Point(125,75)
            temp
        let txt4 =
            let temp = new TextBox()
            temp.Size <- new System.Drawing.Size(200,25)
            temp.Location <- new System.Drawing.Point(125,100)
            temp
        let sign_click sender evargs = 
            MessageBox.Show("Connect clicked!") |> ignore
        let signButton = 
            let temp = new Button()
            temp.Size <- new System.Drawing.Size(100,25)
            temp.Text <- "Connect"
            temp.Location <- new System.Drawing.Point(225,125)
            temp.BackColor <- System.Drawing.Color.Black;
            temp.ForeColor <- System.Drawing.Color.Cyan;
            temp.Click.AddHandler (new System.EventHandler(sign_click))
            temp
        let initializeForm =
            let form = new Form(BackColor = Color.Pink, Text = "F# Form")
            form.Size <- new System.Drawing.Size(375, 225)
            form.FormBorderStyle <- FormBorderStyle.FixedSingle
            form.Controls.Add(lbl1)
            form.Controls.Add(lbl2)
            form.Controls.Add(lbl3)
            form.Controls.Add(lbl4)
            form.Controls.Add(lbl4)
            form.Controls.Add(txt1)
            form.Controls.Add(txt2)
            form.Controls.Add(txt3)
            form.Controls.Add(txt4)
            form.Controls.Add(signButton)
            form
        initializeForm
    
    let load_data (dgv:DataGridView) =
        let dt = new DataTable()
        for i in SQL.gettable do
            dt.Rows.Add([|i.ID.ToString(); i.MSG.ToString()|]) |> ignore
        dgv.DataSource <- dt

    let DATA_FORM = 
        let lbl_returnsize = 
            let temp = new Label()
            temp.Text <- "SHOW:"
            temp.Size <- new Size(50,20)
            temp.Location <- new Point(535,55)
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

        let initializeForm =
            let form = new Form(BackColor = Color.Pink, Text = "F# Form")
            form.Size <- new System.Drawing.Size(665, 500)
            form.FormBorderStyle <- FormBorderStyle.FixedSingle
            form.Controls.Add(ddl_returnsize)
            form.Controls.Add(data_gridview)
            form.Controls.Add(lbl_returnsize)
            form.Controls.Add(txt_search)
            form.Controls.Add(btn_search)
            form.Controls.Add(btn_new)
            form.Controls.Add(btn_edit)
            form.Controls.Add(btn_delete)
            form
        initializeForm

        
            