'''
	StudentList
'''
from student import Student

class StudentList:
    def __init__(self,size)->None: 
        self.slist = []
        self.size = size
        
    def isEmpty(self)->bool:    
        return len(self.slist) == 0
    
    def isFull(self)->bool:     
        return len(self.slist) > self.size
    
    def addStudent(self,s:Student)->bool:
        
        if self.findStudent(s.idno):  
            print("Student with this ID already exists!")
            return False
        if self.isFull():
            print("The list is full. Cannot add more students.")
            return False    
        self.slist.append(s)
        print("Student added successfully.")
        return True
    
    def findStudent(self,idno:str)->Student:
        for student in self.slist:
            if student.idno == idno:
                return student
        return None
    def updateStudent(self, idno:str)->bool:
        student = self.findStudent(idno)
        if not student:
            print("No student found with that ID.")
            return False

        print(f"Student found: {student}")
        option = input("Do you want to update this student's info? (Y/N): ").strip().upper()
        if option != "Y":
            print("Update cancelled.")
            return False

        # Ask new details (Enter blank to keep old value)
        new_fname = input(f"Enter new first name (leave blank to keep '{student.firstname}'): ").strip()
        new_lname = input(f"Enter new last name (leave blank to keep '{student.lastname}'): ").strip()
        new_course = input(f"Enter new course (leave blank to keep '{student.course}'): ").strip()
        new_level = input(f"Enter new year level (leave blank to keep '{student.level}'): ").strip()

        if new_fname: student.firstname = new_fname.title()
        if new_lname: student.lastname = new_lname.title()
        if new_course: student.course = new_course.upper()
        if new_level:
            if new_level.isdigit():
                student.level = new_level
            else:
                print("Invalid year level. Keeping old value.")

        print("Student info updated successfully.")
        return True
        
    
    def deleteStudent(self,idno:str)->bool:
        student = self.findStudent(idno)
        if student:
            print(f"Student to be deleted: {student}")
            option:str = input("Do you really want to delete this Student (Y/N): ")
            if option.upper() == "Y":
                self.slist.remove(student)
                print("Student deleted successfully.")
                return True
            else:
                print("Deletion cancelled!")
                return False
        print("No student found with that ID.")
        return False
    
    def showList(self)->None:
        print(f"IDNO       LASTNAME   FIRSTNAME  COURSE    LEVEL")
        print("-"*120)
        if not self.isEmpty():
            for student in self.slist:
                print(student)
        else:
            print("list is empty".center(120,"-"))
        print(" Nothing follows ".center(120,"-"))
