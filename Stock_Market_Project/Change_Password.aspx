<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="Stock_Market_Project.Change_Password"  EnableEventValidation="false" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Placeholder1" runat="server">

</asp:Content>
<asp:Content ID="Contenttemp" ContentPlaceHolderID="ContentPlaceHoldertemp" runat="server">
     <div class="row main-top-margin text-center">
                <div class="col-md-8 col-md-offset-2 col-sm-10 col-sm-offset-1" data-scrollreveal="enter top and move 100px, wait 0.5s">
                    <h1>Change Password</h1>
                    
                </div>
            
    <div class="col-md-6  col-sm-12" data-scrollreveal="enter right and move 100px, wait 0.8s">
                        
                        <form >
    <div class="col-md-6 col-sm-6">
                                    <div class="form-group">
                                      
                                        <input type="text" class="form-control" required="required" placeholder="Email" style="margin-left:168%;margin-top:20px  ; width:400px" ID="email1_txt" runat="server">
                                          <br />
                                           
                                       <asp:Button ID="send_Mail_Btn" class="btn btn-primary" runat="server" style="margin-left:196% ; margin-bottom:10px" Text="Send Email" OnClick="on_Click_Send_Btn" />
                                       <div  style="width:500px ; margin-left:160% "> <asp:Label ID="lbresult" runat ="server" style="color:red; font-weight:bold "></asp:Label></div>
                                        <asp:Label ID="Label1" runat ="server" style="color:red; font-weight:bold "></asp:Label>
                                    </div>
                                </div>
                             
                                           
                                  
                         
                            </form>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Placeholder2" runat="server">

    
</asp:Content>

