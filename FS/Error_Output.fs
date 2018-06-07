module Error_Output 
    open System
    open System.Windows.Forms
    open System.Drawing

    type error_out() as a = 
        inherit Form()
        let lblErr = 
            let temp = new Label()
            temp.Size <- new Size(350,200)
            temp.Location <- new Point (25,25)
            temp.Font <- new System.Drawing.Font(temp.Font.Name, 9.0F, FontStyle.Bold)
            temp.ForeColor <- Color.DarkRed
            temp
        let close_btn = 
            let temp = new Button()
            temp.Location <- new Point(300,250)
            temp.Size <- new Size(75,25)
            temp.BackColor <- Color.DarkRed
            temp.ForeColor <- Color.WhiteSmoke
            temp.FlatStyle <- FlatStyle.Flat
            temp.FlatAppearance.BorderColor <- Color.Black
            temp.FlatAppearance.BorderSize <- 2
            temp.Text <- "EXIT"
            temp.Click.Add( fun _ ->
                    Application.Exit()
                )
            temp
        do
            a.Text <- "F# Error"
            a.Size <- new Size(400, 325)
            a.FormBorderStyle <- FormBorderStyle.FixedSingle
            a.BackColor <- Color.LightPink
            a.Controls.Add(lblErr)
            a.Controls.Add(close_btn)
            a.FormBorderStyle <- FormBorderStyle.FixedDialog
            a.Icon <- new Icon("msg_error.ico")
            a.MaximizeBox <- false
        member this.show_err(ex: Exception)=
            do 
                lblErr.Text <- "Error: " + ex.Message.ToString()


    let output_err (ex : Exception) = 
        let frm = new error_out()
        frm.show_err(ex)
        frm.ShowDialog() |> ignore
        Application.Exit()