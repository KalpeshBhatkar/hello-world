<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentMaster.aspx.cs" Inherits="StudentMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Full Name : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" />
                        <asp:HiddenField ID="hdfID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Mobile No : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobileNo" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Email : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>DOB : 
                    </td>
                    <td>
                        <asp:Calendar ID="calDOB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Roll No. : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtrollno" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Address : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Subject List : 
                    </td>
                    <td>
                        <asp:CheckBoxList ID="chkSubject" runat="server" RepeatDirection="Horizontal" />

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblStatus" runat="server"  />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" >
                        <asp:Button ID="btnSubmit" runat="server" Text="Insert" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gvStudentMaster" runat="server" AllowPaging="true" PageSize="10" DataKeyNames="StudentID" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Sr.No">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                    <asp:BoundField DataField="EmailID" HeaderText="EmailID" />
                    <asp:BoundField DataField="SDOB" HeaderText="DOB" />
                    <asp:BoundField DataField="RollNo" HeaderText="RollNo" />
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <label>No Data Found!!!</label>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
