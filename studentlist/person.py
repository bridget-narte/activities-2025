'''
	Person class
'''
class Person:
    def __init__(self,lastname:str,firstname:str)->None:
        self.lastname = lastname.strip().title()
        self.firstname = firstname.strip().title()
        
    def __str__(self)->str: 
        return f"{self.lastname:<10} {self.firstname:<10}"
