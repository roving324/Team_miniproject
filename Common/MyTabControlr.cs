using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    // 사용자 정의 컨트롤 생성
    public class MyTabControlr : TabControl
    {
        // 클래스 상속 (MyTabControl 클래스는 TabControl 클래스를 상속 받는다.)
        // 생성되어 있는 클래스의 모든 기능을 그대로 물려받고
        // 새로운 기능을 추가 할 수 있다.

        // TabControl 의 기능을 상속받아
        // 호출된 화면을 탭 페이지 클래스에 포함시켜 화면을 활성화 하는
        // 사용자 정의 컨트롤 메서드 추가.
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
    }
}
