## Структура сцены 
#### ```SceneController```
Базовый класс для стартовых точек сцены. Регистрирует действия, которые должны быть выполнены при загрузке и выгрузке сцены с использованием ```SceneTransactionManager```.
#### ```xxxMenu```
Компоненты отвечающие за иницализацию и активацию UI на сцене. Весь UI реализован с подходом MVP.
#### ```xxxManager```
Синглтоны под разные нужды. Могут как находиться на сцене, так и созданы по требованию из ресурсов (или просто созданы). В данном примере все синглтоны находятся в Resources/Singletons

## Игровая логика
#### ```GameManager```
Хранит в себе данные уровней и текущей прогресс.

#### ```GameField```
Главный игровой объект - игровое поле. Создаёт блоки слов и размещает их в начальный контейнер. Проводит проверку на корректность собранных слов.

#### ```WordBlock```
Объект хранящий часть слова. Поддерживает механику Drag and Drop для переноса в контейнер ```WordContainer```.

#### ```WordContainer```
Хранилище определённого "объёма" для частей слова - ```WordBlock```.

#### ```ScrollRectContainerController```
Компонент, позволяющий взять блок из прокручиваемой области ```ScrollRect```. Распознаёт, когда игрок пытается вытянуть блок и производит замену цели в ```EventSystem```.
