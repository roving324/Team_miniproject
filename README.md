<p align="center" dir="auto">
    <a target="_blank" rel="noopener noreferrer nofollow" href="https://camo.githubusercontent.com/0a8394c0ebe79b04b29d7b9d84399d07ec746f8b761c8251b8c4789ab02b541c/68747470733a2f2f726561646d652d747970696e672d7376672e6865726f6b756170702e636f6d2f3f6c696e65733d48656c6c6f3b57656c636f6d652b746f2b6d792b70726f66696c65213b486176652b612b6c6f6f6b2b61726f756e642126666f6e743d46697261253230436f646526636f6c6f723d2532334436324637392663656e7465723d747275652677696474683d323830266865696768743d3530"><img src="https://camo.githubusercontent.com/0a8394c0ebe79b04b29d7b9d84399d07ec746f8b761c8251b8c4789ab02b541c/68747470733a2f2f726561646d652d747970696e672d7376672e6865726f6b756170702e636f6d2f3f6c696e65733d48656c6c6f3b57656c636f6d652b746f2b6d792b70726f66696c65213b486176652b612b6c6f6f6b2b61726f756e642126666f6e743d46697261253230436f646526636f6c6f723d2532334436324637392663656e7465723d747275652677696474683d323830266865696768743d3530" data-canonical-src="https://readme-typing-svg.herokuapp.com/?lines=Hello;Welcome+to+my+profile!;Have+a+look+around!&amp;font=Fira%20Code&amp;color=%23D62F79&amp;center=true&amp;width=280&amp;height=50" style="max-width: 100%;"></a>
</p>

# Material_Management_System
MES Project - 원자재 관리 시스템

- Languages <br/><img src="https://camo.githubusercontent.com/dd433625a6e00049c26f08143705ff9e32d5da44f503f1be133664b11e37e34b/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f432532332d3233393132303f7374796c653d666f722d7468652d6261646765266c6f676f3d632d7368617270266c6f676f436f6c6f723d7768697465" data-canonical-src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&amp;logo=c-sharp&amp;logoColor=white" style="max-width: 100%;">

- Using Tool <br/>
<img alt="VisualStudio" src ="https://img.shields.io/badge/VisualStudio-5C2D91.svg?&style=for-the-badge&logo=VisualStudio&logoColor=Magenta "/> <img alt="Microsoft SQL Server" src ="https://img.shields.io/badge/Microsoft SQL Server-CC2927.svg?&style=for-the-badge&logo=Microsoft SQL Server&logoColor=sirver"/>

<br/>

# About

<br/>

<P>MES의 제조현장의 정확한 실시간 정보 집계 및 분석을 통하여 생산 활동의 필요한 상황에</P>
<P>즉작적이고 유연하게 대응할 수 있는 '제조실행시스템' 중 하나인 자재 관리 시스템을 구현.</P>
<P>기능: 원자재를 재고 현황, 원자재 발주 및 입고, 원자재 입출 이력 등</P>

<br/>

# Code

<br/>

- 로근인 후 실행
```
 Form_Login _Login = new Form_Login();
_Login.ShowDialog();
if(_Login.Tag == null) Environment.Exit(0);
Form_SVConnect SVC = new Form_SVConnect();
SVC.ShowDialog();
InitializeComponent();
```

<br/>

- 클릭한 품 화면에 띄우기
```
Assembly assembly = Assembly.LoadFrom($"{Application.StartupPath}\\Form_List.Dll");
 Type typeform = assembly.GetType($"Form_List.{e.ClickedItem.Name}", true);
 Form FormMdi = (Form)Activator.CreateInstance(typeform);

 bool bFlag = false;
 for (int i = 0; i <= myTabControlr.TabPages.Count - 1; i++)
 {
     if (myTabControlr.TabPages[i].Name == $"{e.ClickedItem.Name}")
     {
         myTabControlr.SelectedTab = myTabControlr.TabPages[i];
         bFlag = true;
         break;
     }
 }
if (!bFlag) myTabControlr.AddForm(FormMdi);
stsFormName.Text = e.ClickedItem.Name.ToString();
```

<br/>

- 파라메터 사용
```
SqlDataAdapter Adapter = new SqlDataAdapter("SP_ITEMMASTER_S1", sCon);

Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

Adapter.SelectCommand.Parameters.AddWithValue("@ITEMCODE", sItemCode);
Adapter.SelectCommand.Parameters.AddWithValue("@ITEMNAME", sItemName);
Adapter.SelectCommand.Parameters.AddWithValue("@ITEMTYPE", sItemType);

DataTable dtTemp = new DataTable();
Adapter.Fill(dtTemp);

dgvGrid.DataSource = dtTemp;
```

<br/>

- Grid 메서드 생성
```
dtTemp.Columns.Add(sColumID, ColumType);
dgvTemp.DataSource = dtTemp;
dgvTemp.Columns[sColumID].HeaderText = sColumnText;
dgvTemp.Columns[sColumID].Width = ColumWidth;
dgvTemp.Columns[sColumID].DefaultCellStyle.Alignment = Align;
dgvTemp.Columns[sColumID].ReadOnly = !Editable;
```

<br/>

- 사용자 정의 컨트롤 생성
```
 public void AddForm(Form NewForm)
{
    if (NewForm == null) return;  
    NewForm.TopLevel = false;     
    TabPage page = new TabPage(); 
    page.Controls.Clear();        
    page.Controls.Add(NewForm);   
    page.Text = NewForm.Text;     
    page.Name = NewForm.Name;     

    base.TabPages.Add(page);      
    NewForm.Show();               
    base.SelectedTab = page;      
}
```

<br/>

- Format을 이용해 시간 출력
```
stsNowDateTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
```

<br/>

# 개발화면

<br/>

![메인화면](https://github.com/roving324/Material_Management_System/blob/master/Img/Main.PNG)
**메인화면 및 품목조회**
<p>기준이 되는 품목들을 조회하고 원자재에 종류별로 안정재고와 적정재고의 수량을 기입함으로서</p>
<p>자재를 효과적으로 관리할 수 있도록 구현.</p>

<br/>
<hr/>

![발주화면](https://github.com/roving324/Material_Management_System/blob/master/Img/Order.PNG)
**발주관리**
<p>발주 조회시 발주대상 여부를 확인 할 수 있으며 </p>
<p>마지막 입고자, 입고 일시, 현재 입고 수량이 차감된 발주진행수량을 확인할 수 있다.</p>

<br/>
<hr/>

![이력조회](https://github.com/roving324/Material_Management_System/blob/master/Img/List.PNG)
**이력조회**
<p>품목 및 기간에 따라 이력을 조회할 수 있으며 마지막 입고자 및 거래처를 확인할 수 있다.</p>
