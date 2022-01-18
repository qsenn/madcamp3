# madcamp3
Unity와 WebGL을 이용하여 만든 3d 서바이벌 게임

별도의 설치 없이 웹사이트 접속만으로 참여가 가능하다.

소켓 통신을 이용하여 여러 명의 참가자가 동시에 참여가 가능하도록 제작하였다. 

## 게임 설명

### 입장 화면

<img src="https://user-images.githubusercontent.com/62409503/149926254-96197c4d-dcac-493a-abfd-df97baceed69.JPG" width="400" height="200"/>

입장 화면에서 닉네임을 설정하고 Enter 버튼을 누르면 바로 서버에 접속하여 게임에 참여할 수 있다.

### 게임 조작

WASD를 방향키로 사용하며 마우슬 이용하여 시점을 변경할 수 있다. 게임내에는 총, 도끼, 칼의 아이템이 존재하며 이를 이용하여 상대를 공격할 수 있다. 아이템 없이도 상대를 공격할 수 있다. 

Left Shift 키를 누르면서 이동하면 달릴 수 있으며 Space 키로 점프도 가능하다.

#### 아이템 설명

모든 아이템은 마우스 우클릭으로 장착할 수 있고 아이템을 장착하고 있을 경우 다시 이 조작을 누르게 되면 아이템을 드랍하게 된다.

* 칼

<img src="https://user-images.githubusercontent.com/62409503/149926397-576dc9fd-17de-459a-8a5f-556df4c65ee6.JPG" width="200" height="150" />

* 총

<img src="https://user-images.githubusercontent.com/62409503/149926383-d82a568f-85da-4146-a397-bb2ab5e751e5.JPG" width="200" height="150" />
Q버튼을 누르면 발사할 수 있다.

* 도끼

<img src="https://user-images.githubusercontent.com/62409503/149926321-d84ef24b-84a8-44fe-8754-37fe32160763.JPG" width="200" height="150" />
공격력이 높지만 장착할 경우 이동 속도가 느려진다.

### 엔딩 화면
<img src="https://user-images.githubusercontent.com/62409503/149926361-8be4b404-7144-41e8-b1f5-42d1671fb604.JPG" width="400" height="200" />

체력이 0이 되면 엔딩 화면이 뜨면서 게임이 끝난다.

Retry 버튼을 클릭하면 게임을 다시 시작할 수 있다.
