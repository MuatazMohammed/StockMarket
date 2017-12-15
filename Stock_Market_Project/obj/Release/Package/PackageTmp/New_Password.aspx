<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="New_Password.aspx.cs" Inherits="Stock_Market_Project.New_Password"  EnableEventValidation="false" ValidateRequest="false" %>
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
                                      
                                        <input type="password" class="form-control" required="required" placeholder="New Password" style="margin-left:168%;margin-top:20px  ; width:400px" id="npass_txt" runat="server">
                                          
                                           <input type="password" class="form-control" required="required" placeholder="Confirm Password" style="margin-left:168%;margin-top:25px  ; width:400px" id="confpass_txt" runat="server">
                                       <asp:Button ID="Confirm_Btn" class="btn btn-primary" runat="server" style="margin-left:205% ; margin-top:22px " Text="Confirm" OnClick="on_Click_Confirm_Button"  />
                                       <div  style="width:500px ; margin-left:160% "> <asp:Label ID="lbresult" runat ="server" style="color:red; font-weight:bold ; margin-right:390px " ></asp:Label></div>
                                         <div  style="width:500px ; margin-left:197% ;margin-top:5px"><asp:CompareValidator ID="cmp_pass" runat="server" ErrorMessage="Password dont Match" Font-Bold="True" ControlToCompare="npass_txt" ControlToValidate="confpass_txt" style="color:red "></asp:CompareValidator></div>
                                       <div  style="width:500px ; margin-left:197% ;margin-top:5px"> <asp:RegularExpressionValidator ID="revpass" runat="server" ErrorMessage="Choose at  least 6 character with characters,numbers,1 upper case letter and special characters." style="color:red ; margin-left:-213px"  ValidationExpression="(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$" ControlToValidate="npass_txt" Visible="True"></asp:RegularExpressionValidator></div>

                                    </div>
                                </div>
                             
                                           
                                  
                         
                            </form>
        </div>
          </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder2" runat="server">
   
</asp:Content>
