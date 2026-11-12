# 手動テスト手順

Windowsで [WinFormsReusableParts.sln](../WinFormsReusableParts.sln) をVisual Studio 2026で開きます。`WinFormsReusableParts` をスタートアッププロジェクトに設定し、F5で起動します。

| ID | 操作 | 期待結果 |
| --- | --- | --- |
| AC-01 | MainFormで「設定画面を開く」を押す | 親より小さい設定ダイアログが開き、Aが選択される。閉じるまで親画面の操作は待機する |
| AC-02 | A、B、C、D、Eを順に選ぶ | 中央は順に X＋Y、X＋Z、W＋X、Y＋Z、TextBox＋X になる |
| AC-03 | AからBへ切り替える途中で `ShowPage()` の旧ページ取り外し行にブレークポイントを置き、`previousPage` と `currentPage` の `partX` を調べる | どちらも `PartXControl`。二つの参照の `ReferenceEquals` は `false` |
| AC-04 | AでXの「プレビューを表示する」をONにしてBへ移る | BのXのチェックはOFF |
| AC-05 | AでYをONにして「取得」。Bへ移ってXの「プレビューを表示する」だけをONにし、「取得」を押す。続けてチェックを外して「取得」 | 切り替え直後は結果欄が空。Bの取得結果には「プレビューを表示する」だけが入る。チェックを外すと該当なしと表示する |
| AC-06 | Cを選び、WとXの項目をチェックして「取得」 | XはWの下にあり、チェックしたWとXの文字列が表示される |
| AC-07 | Eに `Hello` と入力し、Aへ移ってEに戻る。次にEの入力を全消去し、Aを経由してEへ戻る | 最初は `Hello` が復元され、全消去後は空欄が復元される |
| AC-08 | Aでチェックを入れ、Bへ移ってAに戻る。戻ったAでXを再度チェックし、選択済みのAをもう一度押す | 戻った時点ではチェックがOFF。同じAを押したときは、入れ直したチェックが残る |
| AC-09 | A〜Eを数周する。Eで入力したまま「閉じる」を押し、設定画面を開き直してEを選ぶ | 各モードで部品が重複せず、操作を続けられる。開き直したEは空欄 |
| AC-10 | ビルド後、`PageCView.cs` を右クリックして「デザイナーの表示」。Cの `partX` を選んで `Location` を変更し、再実行する | C上で部品を選択・移動でき、実行時にもCのXに変更が反映される。確認後は座標を戻す |
| AC-11 | WindowsでReleaseビルドし、下記のSmokeTestsを実行する | ビルドに成功し、`PASS:` で始まる行を出力して終了コード0を返す |
| AC-12 | READMEのクラス表、取得ボタン、Eの復元の各節を読んで、Bの取得処理とEの更新処理をコードでたどる | ページが自分の部品だけを参照する箇所と、Controller経由でModelを更新する箇所が見つかる |

AC-03のウォッチ式の例です。切り替え先がBで、旧ページがAのときに評価します。

```csharp
ReferenceEquals(previousPage.Controls.Find("partX", true)[0],
                currentPage.Controls.Find("partX", true)[0])
```

## 配置と操作の確認

- 設定ダイアログを最小サイズまで縮め、CとEの下側の部品までスクロールします。「取得」「閉じる」は下部に残ります。
- Tabキーと矢印キーでモードと部品を操作します。Escでダイアログが閉じ、MainFormに戻ります。
- Windowsの表示倍率を100%、150%、200%にして、モード名、CheckBoxの文言、EのTextBox、結果欄が重なったり欠けたりしないか確認します。

## 自動検証

```powershell
dotnet build WinFormsReusableParts.sln --configuration Release --warnaserror
dotnet run --project SmokeTests/SmokeTests.csproj --configuration Release --no-build
```

SmokeTestsは設定画面を開くボタンと取得・閉じるボタンを実際に呼び出し、ラジオボタンの選択を変えます。切り替え後のPanelにページが1つだけあり、旧ページが1回破棄されることも検証します。候補をPanelへ追加する際に意図的に例外を起こすケースでは、候補の破棄、元ページの状態と選択の保持、その後の再切り替えを確認します。

Visual Studio上で部品をドラッグして保存する確認（AC-10）、キーボード操作、複数DPIでの見た目は手動で実施します。
