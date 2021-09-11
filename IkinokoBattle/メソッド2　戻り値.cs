public String GenerateTestMessage(int value1, int value2) {
  return String.format("{0}と{1}が渡されたよ！", value1, value2);
}

var result = GenerateTestMessage(1, 2);
Debug.Log(result);