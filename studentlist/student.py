'''
	Student class <- inherits from Person class
'''
from person import Person

class Student(Person):
    def __init__(self,idno:str,lastname:str,firstname:str,course:str,level:str)->None:
        super().__init__(lastname,firstname)
        self.idno = idno.strip()
        self.course = course.strip().upper()
        self.level = level.strip()
    
    def __str__(self)->str:
        return f"{self.idno:<10} {super().__str__()} {self.course:<10} {self.level:<5}"
        
    def __eq__(self,other)->bool:
        return isinstance(other,Student) and self.idno == other.idno
