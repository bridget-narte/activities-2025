'''
	StudentList Menu
'''
from student import Student
from studentlist import StudentList
from os import system

"""
           Main Menu
    ----------------------
    1. ADD STUDENT
    2. FIND STUDENT
    3. DELETE STUDENT
    4. DISPLAY ALL STUDENT
    0. QUIT/END
    ----------------------
"""

def displaymenu()->None:
    system('cls')
    for i in range(0,11): print(" "*120)
    print(" "*49,end=""); print(" Main Menu ".center(22))
    print(" "*49,end=""); print("-"*22)
    print(" "*49,end=""); print("1. ADD STUDENT")
    print(" "*49,end=""); print("2. FIND STUDENT")
    print(" "*49,end=""); print("3. DELETE STUDENT")
    print(" "*49,end=""); print("4. DISPLAY ALL STUDENT")
    print(" "*49,end=""); print("0. QUIT/END")
    print(" "*49,end=""); print("-"*22)
    for i in range(0,11): print(" "*120)


def addstudent(s:StudentList) -> None:
    system("cls")
    for i in range(0,11): print(" "*120)
    print(" "*49,end=""); print(" Add Student ".center(25, "-"))

    try:
        print(" "*49,end=""); sid = input("Enter ID: ").strip()
        if not sid.isdigit():
            print("ID must be numeric only!")
            return
        print(" "*49,end=""); fname = input("Enter first name: ").strip()
        print(" "*49,end=""); lname = input("Enter last name: ").strip()
        print(" "*49,end=""); scourse = input("Enter course: ").strip()
        print(" "*49,end=""); slevel = input("Enter year level: ").strip()
        if not slevel.isdigit():
            print("Year level must be numeric only!")
            return

        student = Student(sid, lname, fname, scourse, slevel)
        s.addStudent(student)   # <-- handles printing itself
    except Exception as e:
         print(f"Error: {e}")
    input("Press Enter to continue...")


def findstudent(s:StudentList) -> None:
    system("cls")
    for i in range(0,11): print(" "*120)
    print(" "*49,end=""); print(" Find/Update Student ".center(30, "-"))
    try:
        print(" "*49,end=""); sid = input("Enter ID: ").strip()
        if not sid.isdigit():
            print("ID must be numeric!")
            return
        if not s.updateStudent(sid):
            print("No updates made.")
    except Exception as e:
        print(f"Error: {e}")
    input("Press Enter to continue...")

def deletestudent(s:StudentList) -> None:
    system("cls")
    for i in range(0,11): print(" "*120)  
    print(" "*49,end=""); print(" Delete Student ".center(25, "-"))
    try:
        print(" "*49,end=""); sid = input("Enter ID to delete: ").strip()
        if not s.deleteStudent(sid):
            print("No student found with that ID.")
    except Exception as e: 
        print(f"Error: {e}")
    input("Press Enter to continue...")

def showlist(s:StudentList) -> None:
    system("cls")
    for i in range(0,11): print(" "*120)
    print(" Show List ".center(120, "-"))    
    s.showList()
    input("Press Enter to continue...")

def quit() -> None:
    for i in range(0,11): print(" "*120)
    print("Exiting program. Goodbye!")

def main()->None:
    system("cls")
    try:
        n:int = int(input("Enter maximum number of students: "))
        s = StudentList(n)
        option: str = ""
        while option != "0":
            displaymenu()
            option = input("Enter Option(0..4): ").strip()
            match option:
                case "1": addstudent(s)
                case "2": findstudent(s)
                case "3": deletestudent(s)
                case "4": showlist(s)
                case "0": quit()
                case _: print("Invalid Option")
        input("Press any key to continue..")
    except ValueError:
        print("Input integer values only! >_<")
        
if __name__=="__main__":
    main()
