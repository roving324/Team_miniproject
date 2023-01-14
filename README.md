<p align="center" dir="auto">
    <a target="_blank" rel="noopener noreferrer nofollow" href="https://camo.githubusercontent.com/0a8394c0ebe79b04b29d7b9d84399d07ec746f8b761c8251b8c4789ab02b541c/68747470733a2f2f726561646d652d747970696e672d7376672e6865726f6b756170702e636f6d2f3f6c696e65733d48656c6c6f3b57656c636f6d652b746f2b6d792b70726f66696c65213b486176652b612b6c6f6f6b2b61726f756e642126666f6e743d46697261253230436f646526636f6c6f723d2532334436324637392663656e7465723d747275652677696474683d323830266865696768743d3530"><img src="https://camo.githubusercontent.com/0a8394c0ebe79b04b29d7b9d84399d07ec746f8b761c8251b8c4789ab02b541c/68747470733a2f2f726561646d652d747970696e672d7376672e6865726f6b756170702e636f6d2f3f6c696e65733d48656c6c6f3b57656c636f6d652b746f2b6d792b70726f66696c65213b486176652b612b6c6f6f6b2b61726f756e642126666f6e743d46697261253230436f646526636f6c6f723d2532334436324637392663656e7465723d747275652677696474683d323830266865696768743d3530" data-canonical-src="https://readme-typing-svg.herokuapp.com/?lines=Hello;Welcome+to+my+profile!;Have+a+look+around!&amp;font=Fira%20Code&amp;color=%23D62F79&amp;center=true&amp;width=280&amp;height=50" style="max-width: 100%;"></a>
</p>

# Material_Management_System
MES Project - 원자재 관리 시스템

- Languages <br/><img src="https://camo.githubusercontent.com/dd433625a6e00049c26f08143705ff9e32d5da44f503f1be133664b11e37e34b/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f432532332d3233393132303f7374796c653d666f722d7468652d6261646765266c6f676f3d632d7368617270266c6f676f436f6c6f723d7768697465" data-canonical-src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&amp;logo=c-sharp&amp;logoColor=white" style="max-width: 100%;">

- Using Tool <br/>
<img alt="VisualStudio" src ="https://img.shields.io/badge/VisualStudio-5C2D91.svg?&style=for-the-badge&logo=VisualStudio&logoColor=Magenta "/> <img alt="Microsoft SQL Server" src ="https://img.shields.io/badge/Microsoft SQL Server-CC2927.svg?&style=for-the-badge&logo=Microsoft SQL Server&logoColor=sirver"/>

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
            // 클릭한 매뉴의 CS 파일 타입 확인 및 추출
            Type typeform = assembly.GetType($"Form_List.{e.ClickedItem.Name}", true);
            // Form 형식으로 전환
            Form FormMdi = (Form)Activator.CreateInstance(typeform);
            // 탭 페이지에 폼을 추가하여 오픈한다.

            bool bFlag = false;
            for (int i = 0; i <= myTabControlr.TabPages.Count - 1; i++)
            {
                // 클릭한 매뉴의 이름과 오픈되어있는 페이지의 이름이 같다면.
                if (myTabControlr.TabPages[i].Name == $"{e.ClickedItem.Name}")
                {
                    myTabControlr.SelectedTab = myTabControlr.TabPages[i];
                    bFlag = true;
                    break;
                }
            }
            if (!bFlag) myTabControlr.AddForm(FormMdi);
            stsFormName.Text = e.ClickedItem.Name.ToString(); // 품 클릭 시 품이름 띄우기
```

<br/>

- 파라메터 사용
```
SqlDataAdapter Adapter = new SqlDataAdapter("SP_ITEMMASTER_S1", sCon);

                // Adapter 에게 저장 프로시저 형식의 SQL 을 실행할 것을 등록함.
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 저장 프로시저가 받을 파라매터(인자) 값 설정
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
 // 1. 데이터 테이브에 컬럼과 타입 셋팅
            dtTemp.Columns.Add(sColumID, ColumType);
            // 2. 그리드뷰에 컬럼 셋팅
            dgvTemp.DataSource = dtTemp;
            // 3. 컬럼에 한글 명칭 TEXT 설정
            dgvTemp.Columns[sColumID].HeaderText = sColumnText;
            // 4. 컬럼의 폭 지정
            dgvTemp.Columns[sColumID].Width = ColumWidth;
            // 5. 컬럼 데이터 정렬
            dgvTemp.Columns[sColumID].DefaultCellStyle.Alignment = Align;
            // 6. 컬럼의 수정 여부
            dgvTemp.Columns[sColumID].ReadOnly = !Editable;
```

<br/>

- 사용자 정의 컨트롤 생성
```
 public void AddForm(Form NewForm)
        {
            if (NewForm == null) return;  // 인자로 받은 품이 없을 경우 실행 중지.
            NewForm.TopLevel = false;     // 추가로 호출된 후속품이 두번째, 세번쩨 순으로 생성 되도록 설정.
            TabPage page = new TabPage(); // 탭 페이지 객체 생성.
            page.Controls.Clear();        // 페이지 초기화
            page.Controls.Add(NewForm);   // 페이지 폼 추가
            page.Text = NewForm.Text;     // 폼에서 설정한 명칭으로 탭 페이지 고유 명칭 설정.
            page.Name = NewForm.Name;     // 폼에서 설정한 이름으로 탭 페이지 고유 이름 설정.

            // !!! base : 상속 해준 클래스를 지칭.
            base.TabPages.Add(page);      // 탭 컨트롤에 페이지를 추가한다.
            NewForm.Show();               // 인자로 받은 폼 페이지를 보여준다.
            base.SelectedTab = page;      // 부모 컨트롤 TabControl 에서 현재 선택된 페이지를
                                          // 호출한 폼의 페이지로 설정. (즉 생성된 페이지를 바로 보여준다.)
            
        }
```

<br/>

- Format을 이용해 시간 출력
```
stsNowDateTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
```
