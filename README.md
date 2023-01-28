<p align="center" dir="auto">
    <a target="_blank" rel="noopener noreferrer nofollow" href="https://camo.githubusercontent.com/0a8394c0ebe79b04b29d7b9d84399d07ec746f8b761c8251b8c4789ab02b541c/68747470733a2f2f726561646d652d747970696e672d7376672e6865726f6b756170702e636f6d2f3f6c696e65733d48656c6c6f3b57656c636f6d652b746f2b6d792b70726f66696c65213b486176652b612b6c6f6f6b2b61726f756e642126666f6e743d46697261253230436f646526636f6c6f723d2532334436324637392663656e7465723d747275652677696474683d323830266865696768743d3530"><img src="https://camo.githubusercontent.com/0a8394c0ebe79b04b29d7b9d84399d07ec746f8b761c8251b8c4789ab02b541c/68747470733a2f2f726561646d652d747970696e672d7376672e6865726f6b756170702e636f6d2f3f6c696e65733d48656c6c6f3b57656c636f6d652b746f2b6d792b70726f66696c65213b486176652b612b6c6f6f6b2b61726f756e642126666f6e743d46697261253230436f646526636f6c6f723d2532334436324637392663656e7465723d747275652677696474683d323830266865696768743d3530" data-canonical-src="https://readme-typing-svg.herokuapp.com/?lines=Hello;Welcome+to+my+profile!;Have+a+look+around!&amp;font=Fira%20Code&amp;color=%23D62F79&amp;center=true&amp;width=280&amp;height=50" style="max-width: 100%;"></a>
</p>

# Material_Management_System
MMS Project - 자재 관리 시스템

- Languages <br/><img src="https://camo.githubusercontent.com/dd433625a6e00049c26f08143705ff9e32d5da44f503f1be133664b11e37e34b/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f432532332d3233393132303f7374796c653d666f722d7468652d6261646765266c6f676f3d632d7368617270266c6f676f436f6c6f723d7768697465" data-canonical-src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&amp;logo=c-sharp&amp;logoColor=white" style="max-width: 100%;">

- Using Tool <br/>
<img alt="VisualStudio" src ="https://img.shields.io/badge/VisualStudio-5C2D91.svg?&style=for-the-badge&logo=VisualStudio&logoColor=Magenta "/> <img alt="Microsoft SQL Server" src ="https://img.shields.io/badge/Microsoft SQL Server-CC2927.svg?&style=for-the-badge&logo=Microsoft SQL Server&logoColor=sirver"/>

<br/>

# About

<br/>

<P>MES의 제조현장의 정확한 실시간 정보 집계 및 분석을 통하여 생산 활동의 필요한 상황에</P>
<P>즉작적이고 유연하게 대응할 수 있는 '제조실행시스템' 중 하나인 자재 관리 시스템을 구현.</P>
<P>기능: 원자재를 재고 현황, 원자재 안정재고와 적정재고에 따른 발주 및 입고, 원자재 입출 이력 등</P>

<br/>

# 요구사항
![요구사항](https://github.com/roving324/Material_Management_System/blob/master/Img/%EC%9A%94%EA%B5%AC%EC%82%AC%ED%95%AD.PNG)

<br/>

# TO-BE 프로세스
![TO-BE 프로세스](https://github.com/roving324/Material_Management_System/blob/master/Img/ToBe.PNG)

<br/>

![TO-BE 프로세스](https://github.com/roving324/Material_Management_System/blob/master/Img/ToBe2.PNG)

<br/>

# 개발리스트
![개발리스트](https://github.com/roving324/Material_Management_System/blob/master/Img/%EA%B0%9C%EB%B0%9C%EB%A6%AC%EC%8A%A4%ED%8A%B8.PNG)

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

- 다중 막대 차트
```
 chartItem.Series.Clear();
                
 //2. 조회된 DataTable 의 가장 큰 생산 수량을 Y 축에 셋팅
 int iMaxQty = 0;
 for (int i = 0; i < dtTemp.Rows.Count; i++)
 {
     if (Convert.ToInt32(dtTemp.Rows[i]["WEARINGCOUNT"]) > iMaxQty)
     {
         iMaxQty = Convert.ToInt32(dtTemp.Rows[i]["WEARINGCOUNT"]);
     }
 }
 //iMaxQty: 최대수량
 
 DataRow[] dr = dtTemp.Select("WEARINGCOUNT = MAX(WEARINGCOUNT)"); // [] MAX 값이 여러개라면

 chartItem.ChartAreas[0].AxisY.Minimum = 0;
 chartItem.ChartAreas[0].AxisY.Maximum = Convert.ToInt32(dr[0]["WEARINGCOUNT"]) + 5;
 
 // 3. 데이터 테이블을 차트에 바인딩 (매핑)
 chartItem.DataBindTable(dtTemp.DefaultView, "WEARINGDATE");

 // 4. 막대 차트로 표현해야 하는 데이터의 이름과 설정 정보 등록.
 chartItem.Series[0].Name = Convert.ToString(dtTemp.Rows[0]["ITEMNAME"]);
 chartItem.Series[0].Color = Color.Blue;        
 chartItem.Series[0].IsValueShownAsLabel = true;
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

## 발주관리 조회(SQL)
```
SELECT A.ITEMCODE
	  ,A.ITEMNAME
	  ,A.MATERIALCOUNT
	  ,A.REGISTRANT
	  ,A.WEARINGDATE
	  ,A.ORDERFLAG
	  ,A.NOWORDERCOUNT
  FROM(   SELECT A.ITEMCODE		AS ITEMCODE		
	           ,B.ITEMNAME      AS ITEMNAME      
	           ,C.MATERIALCOUNT AS MATERIALCOUNT 
			   ,A.REGISTRANT	AS REGISTRANT	
			   ,A.WEARINGDATE	AS WEARINGDATE	
			   ,(CASE WHEN  ISNULL(C.MATERIALCOUNT,0) + ISNULL(A.NOWORDERCOUNT,0) >= B.STABLESTOCK THEN 'N'
	                  ELSE 'Y' 
		               END)     AS ORDERFLAG
			   ,A.NOWORDERCOUNT AS NOWORDERCOUNT
	       FROM(  SELECT A.ITEMCODE	                                                       AS ITEMCODE	
                        ,C.REGISTRANT	                                                   AS REGISTRANT	
		                ,C.WEARINGDATE                                                     AS WEARINGDATE
		                ,(CASE WHEN SUM(ORDERCOUNT) - ISNULL(B.WEARINGCOUNT,0) < 0 THEN 0
						       ELSE SUM(ORDERCOUNT) - ISNULL(B.WEARINGCOUNT,0) END)        AS NOWORDERCOUNT
			        FROM TB_Order A LEFT JOIN (  SELECT ITEMCODE          AS ITEMCODE
			                                           ,SUM(WEARINGCOUNT) AS WEARINGCOUNT
			   							           FROM TB_WEARING 
			   							       GROUP BY ITEMCODE) B
			                               ON A.ITEMCODE = B.ITEMCODE
			                        LEFT JOIN TB_WEARING C
			                               ON A.ITEMCODE = C.ITEMCODE
									WHERE C.ENDFLAG = 'Y'
                GROUP BY A.ITEMCODE , B.WEARINGCOUNT, C.REGISTRANT ,C.WEARINGDATE
			)A LEFT JOIN TB_ITEMMASTER B
			          ON A.ITEMCODE = B.ITEMCODE
			   LEFT JOIN TB_MATERIAL C
			          ON A.ITEMCODE = C.ITEMCODE

          UNION ALL

         SELECT A.ITEMCODE	                                                                AS ITEMCODE	   
		       ,C.ITEMNAME	                                                                AS ITEMNAME	   
		       ,A.MATERIALCOUNT                                                             AS MATERIALCOUNT
		       ,D.REGISTRANT                                                                AS REGISTRANT   
		       ,D.WEARINGDATE                                                               AS WEARINGDATE  
		       ,(CASE WHEN  A.MATERIALCOUNT + E.NOWORDERCOUNT >= C.STABLESTOCK THEN 'N'
	                  ELSE 'Y' 
		               END)                                                                 AS ORDERFLAG
		       ,ISNULL(SUM(B.ORDERCOUNT),'')                                                AS NOWORDERCOUNT
           FROM TB_MATERIAL A LEFT JOIN TB_Order B
                                     ON A.ITEMCODE = B.ITEMCODE
          					  LEFT JOIN TB_ITEMMASTER C
          					         ON A.ITEMCODE = C.ITEMCODE
          					  LEFT JOIN TB_WEARING D
          					         ON A.ITEMCODE = D.ITEMCODE
          				      LEFT JOIN (  SELECT A.ITEMCODE
					                             ,(CASE WHEN SUM(ORDERCOUNT) - ISNULL(B.WEARINGCOUNT,0) <0 THEN 0
						                                ELSE SUM(ORDERCOUNT) - ISNULL(B.WEARINGCOUNT,0) END)     AS NOWORDERCOUNT
							                 FROM TB_Order A LEFT JOIN (  SELECT ITEMCODE          AS ITEMCODE
											                                    ,SUM(WEARINGCOUNT) AS WEARINGCOUNT 
											                                FROM TB_WEARING 
											                            GROUP BY ITEMCODE) B
											   		                ON A.ITEMCODE = B.ITEMCODE
							             GROUP BY A.ITEMCODE , B.WEARINGCOUNT) E
								     ON A.ITEMCODE = E.ITEMCODE
          WHERE (B.ORDERCOUNT IS NOT NULL
            AND D.REGISTRANT IS NULL) OR (B.ORDERCOUNT IS NULL AND D.WEARINGCOUNT IS NULL)
       GROUP BY A.ITEMCODE, C.ITEMNAME, A.MATERIALCOUNT, D.REGISTRANT, D.WEARINGDATE, A.ORDERFLAG, E.NOWORDERCOUNT, C.STABLESTOCK) A
 WHERE A.ITEMCODE  LIKE '%' + @ITEMCODE + '%'
   AND A.ITEMNAME  LIKE '%' + @ITEMNAME + '%'
   AND A.ORDERFLAG LIKE '%' + @OderFlag
```
<br/>
<hr/>

![입고관리](https://github.com/roving324/Material_Management_System/blob/master/Img/WEARING.PNG)
**입고관리**

<br/>
<hr/>

![발주이력조회](https://github.com/roving324/Material_Management_System/blob/master/Img/OrderList.PNG)
**발주이력조회**

<br/>
<hr/>

![입고이력조회](https://github.com/roving324/Material_Management_System/blob/master/Img/List.PNG)
**입고이력조회**
<p>품목 및 기간에 따라 이력을 조회할 수 있으며 마지막 입고자 및 거래처를 확인할 수 있다.</p>
