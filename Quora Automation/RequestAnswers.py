import pyautogui
import time
time.sleep(5)

def getAnswerAddBtn():
    return pyautogui.locateOnScreen('AnswerAddBtn.png')

def getQuestionBtnLocation():
    return pyautogui.locateOnScreen('QuestionAddBtn.png')

def getDoneBtnLocation():
    return pyautogui.locateOnScreen('DoneBtn.png')

scroll = False
scrolltry =0

def selectQuestion():
    time.sleep(0.3)
    AddBtnLocation = getQuestionBtnLocation()
    if AddBtnLocation != None:
        buttonx, buttony = pyautogui.center(AddBtnLocation)
        pyautogui.click(buttonx, buttony) 

def requestAnswer():
   time.sleep(0.4)
   global scroll
   global scrolltry
   AddBtnLocation = getAnswerAddBtn()
   if AddBtnLocation != None:
        buttonx, buttony = pyautogui.center(AddBtnLocation)
        pyautogui.click(buttonx, buttony)
        scroll = False
        scrolltry=0
   elif scroll == False:
        pyautogui.scroll(-5)
        scroll = True
   else:
        scrolltry+=1

for questions in range(450):
    selectQuestion()
    time.sleep(0.2)
    for request in range(40):
        if(scrolltry>2):
            break
        requestAnswer()
    scrolltry=0
    DoneBtnLocation = getDoneBtnLocation()
    if DoneBtnLocation != None:
        buttonx, buttony = pyautogui.center(DoneBtnLocation)
        pyautogui.click(buttonx, buttony)
        time.sleep(1)
        pyautogui.scroll(-13)
