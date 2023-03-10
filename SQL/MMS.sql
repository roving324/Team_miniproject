USE [TEAM2]
GO
/****** Object:  Table [dbo].[TB_ITEMMASTER]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ITEMMASTER](
	[ITEMCODE] [varchar](50) NOT NULL,
	[ITEMNAME] [varchar](50) NULL,
	[ITEMTYPE] [varchar](50) NULL,
	[STABLESTOCK] [varchar](50) NULL,
	[PROPERSTOCK] [varchar](50) NULL,
 CONSTRAINT [PK_TB_ITEMMASTER] PRIMARY KEY CLUSTERED 
(
	[ITEMCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_MATERIAL]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_MATERIAL](
	[ITEMCODE] [varchar](30) NOT NULL,
	[MATERIALCOUNT] [int] NULL,
	[ORDERFLAG] [varchar](1) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[ITEMCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_Order]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Order](
	[ORDERCODE] [varchar](50) NOT NULL,
	[ITEMCODE] [varchar](50) NOT NULL,
	[ORDERCOUNT] [int] NULL,
	[WEARINGCOUNT] [varchar](30) NULL,
	[OWNER] [varchar](30) NULL,
	[ORDERDATE] [varchar](50) NULL,
	[BUSINESS] [varchar](30) NULL,
 CONSTRAINT [PK_TB_Order] PRIMARY KEY CLUSTERED 
(
	[ORDERCODE] ASC,
	[ITEMCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_WEARING]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_WEARING](
	[ORDERCODE] [varchar](30) NOT NULL,
	[ITEMCODE] [varchar](50) NOT NULL,
	[REGISTRANT] [varchar](30) NULL,
	[WEARINGDATE] [varchar](50) NULL,
	[WEARINGCOUNT] [int] NULL,
	[ENDFLAG] [varchar](1) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_ITEMCbo_S1]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김수환, 황준영
-- Create date: 2022-12-23
-- Description:	품목 타입 조회
-- =============================================
CREATE PROCEDURE [dbo].[SP_ITEMCbo_S1]

AS
BEGIN
  SELECT ''       AS ITEM_TYPE
        ,'ALL'    AS ITEMTYPE
UNION ALL

  SELECT ITEMTYPE AS ITEM_TYPE
        ,ITEMTYPE AS ITEMTYPE
    FROM TB_ITEMMASTER
GROUP BY ITEMTYPE



END
GO
/****** Object:  StoredProcedure [dbo].[SP_ITEMMASTER_S1]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김수환, 황준영
-- Create date: 2022-12-23
-- Description:	품목 마스터 조회
-- =============================================
CREATE PROCEDURE [dbo].[SP_ITEMMASTER_S1]
  @ITEMCODE   VARCHAR(50)       -- 품목코드
 ,@ITEMNAME   VARCHAR(50)       -- 품목명
 ,@ITEMTYPE   VARCHAR(50)       -- 품목타입
AS
BEGIN
 SELECT ITEMCODE	-- 품목코드
       ,ITEMNAME    -- 품목명
	   ,ITEMTYPE    -- 품목타입
	   ,STABLESTOCK -- 안정재고
	   ,PROPERSTOCK -- 적정재고
   FROM TB_ITEMMASTER
  WHERE ITEMCODE LIKE '%' + @ITEMCODE + '%'
    AND ITEMNAME LIKE '%' + @ITEMNAME + '%'
	AND ITEMTYPE LIKE '%' + @ITEMTYPE
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MATERIAl_S1]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김수환, 황준영
-- Create date: 2022-12-23
-- Description:	자재 현황 조회
-- =============================================
CREATE PROCEDURE [dbo].[SP_MATERIAl_S1]
  @ITEMCODE   VARCHAR(50)       -- 품목코드
 ,@ITEMNAME VARCHAR(50)         -- 품목명

AS
BEGIN
  SELECT ITEMCODE	  -- 품목코드   
	    ,ITEMNAME      -- 품목명
	    ,MATERIALCOUNT -- 품목타입
	    ,REGISTRANT    -- 입고자
    FROM(SELECT A.ITEMCODE	    AS ITEMCODE      
               ,B.ITEMNAME      AS ITEMNAME      
	           ,A.MATERIALCOUNT AS MATERIALCOUNT 
	           ,C.REGISTRANT    AS REGISTRANT    
           FROM TB_MATERIAL A LEFT JOIN TB_ITEMMASTER  B 
                                     ON A.ITEMCODE = B.ITEMCODE
					          LEFT JOIN TB_WEARING C
					                 ON A.ITEMCODE = C.ITEMCODE
          WHERE C.REGISTRANT IS NULL
          UNION ALL
         SELECT A.ITEMCODE      AS ITEMCODE
               ,B.ITEMNAME      AS ITEMNAME
      	       ,C.MATERIALCOUNT AS MATERIALCOUNT
      	       ,A.REGISTRANT    AS REGISTRANT
           FROM TB_WEARING A LEFT JOIN TB_ITEMMASTER B
      	                            ON A.ITEMCODE = B.ITEMCODE
      					     LEFT JOIN TB_MATERIAL C
      					            ON A.ITEMCODE = C.ITEMCODE
          WHERE A.ENDFLAG = 'Y' 
		    AND A.WEARINGDATE IN (  SELECT MAX(WEARINGDATE) 
      	                              FROM TB_WEARING 
      						      GROUP BY ORDERCODE)) A
   WHERE ITEMCODE LIKE '%' + @ITEMCODE + '%'
     AND ITEMNAME LIKE '%' + @ITEMNAME + '%'
ORDER BY ITEMCODE
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ORDER_I1]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김수환, 황준영
-- Create date: 2022-12-23
-- Description:	발주 등록
-- =============================================
CREATE PROCEDURE [dbo].[SP_ORDER_I1]
  @OrderCode  VARCHAR(50) -- 발주코드
 ,@ItemCode	  VARCHAR(50) -- 품목코드
 ,@Business   VARCHAR(50) -- 거래처
 ,@OrderCount VARCHAR(50) -- 발주수량

AS
BEGIN

 INSERT INTO TB_Order( ORDERCODE,  ITEMCODE,  ORDERCOUNT,  OWNER  ,       ORDERDATE        ,  BUSINESS)
               VALUES(@ORDERCODE, @ITEMCODE, @OrderCount, '관리자', CONVERT(date,GETDATE()), @Business)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ORDER_I2]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김수환, 황준영
-- Create date: 2022-12-23
-- Description:	입고 등록
-- =============================================
CREATE PROCEDURE [dbo].[SP_ORDER_I2]
  @OrderCode    VARCHAR(80) -- 발주코드
 ,@ItemCode	    VARCHAR(50) -- 품목코드
 ,@Registrant   VARCHAR(50) -- 입고자
 ,@WearingCount VARCHAR(50) -- 입고수량
AS
BEGIN
 UPDATE TB_WEARING
    SET ENDFLAG = ''
  WHERE ITEMCODE = @ItemCode

 INSERT INTO TB_WEARING( ORDERCODE,  ITEMCODE,  WearingCount,  REGISTRANT,  WEARINGDATE          , ENDFLAG)
                 VALUES(@OrderCode, @ItemCode, @WearingCount, @Registrant, CONVERT(date,GETDATE()), 'Y')

 UPDATE TB_MATERIAL
    SET MATERIALCOUNT += @WearingCount
  WHERE ITEMCODE = @ItemCode

END
GO
/****** Object:  StoredProcedure [dbo].[SP_ORDER_S1]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김수환, 황준영
-- Create date: 2022-12-23
-- Description:	발주 대상 재고 조회
-- =============================================
CREATE PROCEDURE [dbo].[SP_ORDER_S1]
  @ITEMCODE   VARCHAR(50)       -- 품목코드
 ,@ITEMNAME VARCHAR(50)         -- 품목명
 ,@OderFlag VARCHAR(1)          -- 발주대상여부
AS
BEGIN
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
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ORDER_S2]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김수환, 황준영
-- Create date: 2022-12-23
-- Description:	발주 신청 내역 조회
-- =============================================
CREATE PROCEDURE [dbo].[SP_ORDER_S2]
  @ITEMCODE   VARCHAR(50)       -- 품목코드
 ,@ITEMNAME VARCHAR(50)         -- 품목명
 ,@StartDate VARCHAR(50)          -- 발주일자
 ,@EndDate VARCHAR(50)
AS
BEGIN
SELECT B.ORDERCODE    AS ORDERCODE    -- 발주코드 
      ,A.ITEMCODE     AS ITEMCODE     -- 품목코드
      ,A.ITEMNAME     AS ITEMNAME     -- 품목명 
      ,B.OWNER        AS OWNER        -- 발주자
      ,B.ORDERDATE    AS ORDERDATE    -- 발주일자
      ,B.ORDERCOUNT   AS ORDERCOUNT   -- 발주수량
      ,C.WEARINGCOUNT AS REMAINCOUNT  -- 발주진행수량
      ,B.BUSINESS     AS BUSINESS     -- 거래처
  FROM TB_ItemMaster A LEFT JOIN TB_Order B
                              ON A.ITEMCODE = B.ITEMCODE
					   LEFT JOIN (  SELECT ORDERCODE         AS ORDERCODE
					                      ,SUM(WEARINGCOUNT) AS WEARINGCOUNT 
							          FROM TB_WEARING 
							      GROUP BY ORDERCODE) C
						      ON B.ORDERCODE = C.ORDERCODE
 WHERE A.ITEMCODE LIKE '%' + @ITEMCODE + '%'
   AND A.ITEMNAME LIKE '%' + @ITEMNAME + '%'
   AND B.ORDERDATE BETWEEN @StartDate AND @EndDate
   AND B.ORDERCOUNT - ISNULL(C.WEARINGCOUNT,0) > 0


END
GO
/****** Object:  StoredProcedure [dbo].[SP_ORDERFLAG_S1]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김수환, 황준영
-- Create date: 2022-12-23
-- Description:	발주 여부 조회
-- =============================================
CREATE PROCEDURE [dbo].[SP_ORDERFLAG_S1]
  @ITEMCODE   VARCHAR(50)       -- 품목코드
 ,@OrderCount  VARCHAR(50)

AS
BEGIN
SELECT(CASE WHEN  @OrderCount + ISNULL(B.MATERIALCOUNT,0) + ISNULL(C.NOWORDERCOUNT,0) < STABLESTOCK THEN 0
            WHEN  @OrderCount + ISNULL(B.MATERIALCOUNT,0) + ISNULL(C.NOWORDERCOUNT,0) > PROPERSTOCK THEN 1               
             END) AS ORDERFLAG
  FROM TB_ITEMMASTER A LEFT JOIN TB_MATERIAL B
                              ON A.ITEMCODE = B.ITEMCODE
				       LEFT JOIN (  SELECT A.ITEMCODE                                AS ITEMCODE
			                             ,SUM(ORDERCOUNT) - ISNULL(B.WEARINGCOUNT,0) AS NOWORDERCOUNT
					                  FROM TB_Order A LEFT JOIN (  SELECT ITEMCODE          AS ITEMCODE
									                                     ,SUM(WEARINGCOUNT) AS WEARINGCOUNT
																     FROM TB_WEARING
																 GROUP BY ITEMCODE) B
												             ON A.ITEMCODE = B.ITEMCODE
					              GROUP BY A.ITEMCODE , B.WEARINGCOUNT) C
							  ON A.ITEMCODE = C.ITEMCODE
 WHERE A.ITEMCODE = @ITEMCODE

 UNION ALL

SELECT COUNT(*) AS ORDERFLAG
  FROM TB_Order

END
GO
/****** Object:  StoredProcedure [dbo].[SP_ORDERFLAG_S2]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김수환, 황준영
-- Create date: 2022-12-23
-- Description:	입고 여부 조회
-- =============================================
CREATE PROCEDURE [dbo].[SP_ORDERFLAG_S2]
  @ITEMCODE      VARCHAR(50)  -- 품목코드
 ,@WearingCount  VARCHAR(50)  -- 입고수량

AS
BEGIN
SELECT(CASE WHEN  @WearingCount  < A.ORDERCOUNT - ISNULL(B.WEARINGCOUNT,0) THEN 0
            WHEN  @WearingCount > A.ORDERCOUNT - ISNULL(B.WEARINGCOUNT,0) THEN 1	               
             END) AS ORDERFLAG
 FROM TB_Order A LEFT JOIN TB_WEARING B
                        ON A.ORDERCODE = B.ORDERCODE
WHERE A.ITEMCODE = @ITEMCODE

END
GO
/****** Object:  StoredProcedure [dbo].[SP_ORDERLIST_S1]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김수환, 황준영
-- Create date: 2022-12-23
-- Description:	발주 내역 조회
-- =============================================
CREATE PROCEDURE [dbo].[SP_ORDERLIST_S1]
  @ITEMCODE  VARCHAR(50)  -- 품목코드
 ,@ITEMNAME  VARCHAR(50)  -- 품목명
 ,@OWNER     VARCHAR(50)  -- 발주자
 ,@StartDate VARCHAR(50)  -- 발주일자
 ,@EndDate   VARCHAR(50)  -- 발주일자
AS
BEGIN
SELECT B.ORDERCODE    -- 발주코드 
      ,A.ITEMCODE     -- 품목코드
      ,A.ITEMNAME     -- 품목명 
      ,B.OWNER        -- 발주자
      ,B.ORDERDATE    -- 발주일자
	  ,B.ORDERCOUNT   -- 발주수량
	  ,B.BUSINESS     -- 거래처
	  ,C.WEARINGCOUNT -- 입고수량
  FROM TB_ItemMaster A LEFT JOIN TB_Order B
                              ON A.ITEMCODE = B.ITEMCODE
					   LEFT JOIN TB_WEARING C
						      ON A.ITEMCODE = C.ITEMCODE
 WHERE A.ITEMCODE  LIKE '%' + @ITEMCODE + '%'
   AND A.ITEMNAME  LIKE '%' + @ITEMNAME + '%'
   AND B.OWNER     LIKE '%' + @OWNER    + '%'
   AND B.ORDERDATE BETWEEN @StartDate AND @EndDate

END
GO
/****** Object:  StoredProcedure [dbo].[SP_WearingCbo_S1]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김수환, 황준영
-- Create date: 2022-12-23
-- Description:	입고 품목 종류 조회
-- =============================================
CREATE PROCEDURE [dbo].[SP_WearingCbo_S1]

AS
BEGIN
SELECT A.ITEMCODE AS ITEM_CODE
      ,A.ITEMCODE AS ITEMCODE
  FROM TB_MATERIAL A LEFT JOIN (  SELECT ITEMCODE        AS ITEMCODE
                                        ,COUNT(ITEMCODE) AS ITEMCOUNT
								    FROM TB_WEARING
								GROUP BY ITEMCODE) B
                            ON A.ITEMCODE = B.ITEMCODE
 WHERE B.ITEMCOUNT IS NOT NULL

END
GO
/****** Object:  StoredProcedure [dbo].[SP_WearingList_S1]    Script Date: 2023-01-26 오후 11:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김수환, 황준영
-- Create date: 2022-12-23
-- Description:	입고 내역 조회
-- =============================================
CREATE PROCEDURE [dbo].[SP_WearingList_S1]
  @ITEMCODE  VARCHAR(50) -- 품목코드
 ,@StartDate VARCHAR(50) -- 입고일자
 ,@EndDate   VARCHAR(50) -- 입고일자
AS
BEGIN
SELECT A.ORDERCODE    -- 발주코드 
      ,A.ITEMCODE     -- 품목코드
      ,B.ITEMNAME     -- 품목명 
      ,A.REGISTRANT   -- 입고자
      ,A.WEARINGDATE  -- 입고일자
	  ,A.WEARINGCOUNT -- 입고수량
	  ,C.BUSINESS     -- 거래처
  FROM TB_WEARING A LEFT JOIN TB_ITEMMASTER B
                           ON A.ITEMCODE = B.ITEMCODE
					LEFT JOIN TB_Order C
					       ON A.ORDERCODE = C.ORDERCODE
 WHERE A.ITEMCODE =  @ITEMCODE
   AND A.WEARINGDATE BETWEEN @StartDate AND @EndDate

END
GO
