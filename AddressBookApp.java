import javax.swing.*;
import java.util.*;
import java.awt.Color;
import java.awt.Font;

class Address {
    String street, city, zipCode;

    public Address(String street, String city, String zipCode) {
        street = street;
        city = city;
        zipCode = zipCode;
    }

    @Override
    public String toString() {
        return street + ", " + city + " " + zipCode;
    }
}

class Person {
    String firstName, lastName;

    public Person(String firstName, String lastName) {
        firstName = firstName;
        lastName = lastName;
    }

    @Override
    public String toString() {
        return firstName + " " + lastName;
    }
}

class DateOfBirth {
    int month, day, year;

    public DateOfBirth(int month, int day, int year) {
        month = month;
        day = day;
        year = year;
    }

    @Override
    public String toString() {
        return month + "/" + day + "/" + year;
    }
}

class ExtPerson extends Person {
    Address address;
    DateOfBirth dateOfBirth;
    String phoneNumber;
    String personType; // family, friend, business

    public ExtPerson(String firstName, String lastName, Address address, DateOfBirth dateOfBirth, String phoneNumber, String personType) {
        super(firstName, lastName);
        address = address;
        dateOfBirth = dateOfBirth;
        phoneNumber = phoneNumber;
        personType = personType;
    }

    @Override
    public String toString() {
        return "Name: " + super.toString() + "\n" +
               "Type: " + personType + "\n" +
               "Phone: " + phoneNumber + "\n" +
               "Address: " + address + "\n" +
               "DOB: " + dateOfBirth;
    }
}

class AddressBook {
    private class Node {
        ExtPerson person;
        Node next;

        public Node(ExtPerson person) {
            person = person;
            next = null;
        }
    }

    private Node head;

    public AddressBook() {
        head = null;
    }

    // Add a person to the address book
    public void addPerson(ExtPerson person) {
        if (head == null) {
            head = new Node(person);
        } else {
            Node current = head;
            while (current.next != null) {
                current = current.next;
            }
            current.next = new Node(person);
        }
    }

    // Search for all people by last name
    public List<ExtPerson> searchByLastName(String lastName) {
        List<ExtPerson> peopleWithSameLastName = new ArrayList<>();
        Node current = head;
        while (current != null) {
            if (current.person.lastName.equalsIgnoreCase(lastName)) {
                peopleWithSameLastName.add(current.person);
            }
            current = current.next;
        }
        return peopleWithSameLastName;
    }

    // Delete a person by last name
    public boolean deletePerson(String lastName) {
        if (head == null) return false;
        if (head.person.lastName.equalsIgnoreCase(lastName)) {
            head = head.next;
            return true;
        }

        Node current = head;
        while (current.next != null) {
            if (current.next.person.lastName.equalsIgnoreCase(lastName)) {
                current.next = current.next.next;
                return true;
            }
            current = current.next;
        }
        return false;
    }

    // Print person details by last name
    public void printPersonInfo(String lastName) {
        List<ExtPerson> people = searchByLastName(lastName);
        if (people.size() == 1) {
            // If only one match, print the info directly
            JOptionPane.showMessageDialog(null, people.get(0).toString());
        } else if (people.size() > 1) {
            // If multiple matches, ask the user to select the correct person
            StringBuilder message = new StringBuilder("Multiple people found with last name " + lastName + ":\n");
            for (int i = 0; i < people.size(); i++) {
                message.append((i + 1) + ". " + people.get(i).firstName + " " + people.get(i).lastName + "\n");
            }
            String choiceStr = JOptionPane.showInputDialog(message.toString() + "Please enter the number of the person you're referring to:");

            try {
                int choice = Integer.parseInt(choiceStr) - 1;
                if (choice >= 0 && choice < people.size()) {
                    JOptionPane.showMessageDialog(null, people.get(choice).toString());
                } else {
                    JOptionPane.showMessageDialog(null, "Invalid choice.");
                }
            } catch (NumberFormatException e) {
                JOptionPane.showMessageDialog(null, "Invalid input. Please enter a valid number.");
            }
        } else {
            JOptionPane.showMessageDialog(null, "No person found with the last name " + lastName);
        }
    }

    // Print birthdays in a given month between two dates
    public void printBirthdaysInMonth(int month, int startDate, int endDate) {
        Node current = head;
        StringBuilder result = new StringBuilder();
        while (current != null) {
            DateOfBirth dob = current.person.dateOfBirth;
            if (dob.month == month && dob.day >= startDate && dob.day <= endDate) {
                result.append(current.person).append("\n");
            }
            current = current.next;
        }
        if (result.length() > 0) {
            JOptionPane.showMessageDialog(null, result.toString());
        } else {
            JOptionPane.showMessageDialog(null, "No birthdays found in that range.");
        }
    }

    // Print people between two last names
    public void printPeopleBetweenLastNames(String startLastName, String endLastName) {
        List<ExtPerson> people = new ArrayList<>();
        Node current = head;
        while (current != null) {
            if (current.person.lastName.compareToIgnoreCase(startLastName) >= 0 && current.person.lastName.compareToIgnoreCase(endLastName) <= 0) {
                people.add(current.person);
            }
            current = current.next;
        }
        Collections.sort(people, Comparator.comparing(p -> p.lastName.toLowerCase()));
        if (!people.isEmpty()) {
            StringBuilder result = new StringBuilder();
            for (ExtPerson person : people) {
                result.append(person).append("\n");
            }
            JOptionPane.showMessageDialog(null, result.toString());
        } else {
            JOptionPane.showMessageDialog(null, "No people found in that range.");
        }
    }
}

public class AddressBookApp {
    public static void main(String[] args) {
        try {
            UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
        } catch (Exception e) {
            e.printStackTrace();
        }

        // Customize the overall look and feel of the JOptionPane
        UIManager.put("OptionPane.background", new Color(25, 25, 112)); // Midnight Blue background
        UIManager.put("Panel.background", new Color(25, 25, 112)); // Same Midnight Blue for the panel
        UIManager.put("OptionPane.messageForeground", Color.WHITE); // White text for contrast
        UIManager.put("OptionPane.buttonBackground", new Color(0, 123, 255)); // Blue button background
        UIManager.put("OptionPane.buttonForeground", Color.WHITE); // White text on buttons
        UIManager.put("OptionPane.font", new Font("Segoe UI", Font.PLAIN, 14)); // Clean font

        AddressBook addressBook = new AddressBook();

        // Add some test data
        addressBook.addPerson(new ExtPerson("April", "Escuadro", new Address("123 Elm St", "City A", "10001"), new DateOfBirth(5, 12, 1990), "555-1234", "family"));
        addressBook.addPerson(new ExtPerson("Dianne", "Escuadro", new Address("456 Oak St", "City B", "10002"), new DateOfBirth(6, 15, 1988), "555-5678", "friend"));

        while (true) {
            String menu = "<html><body style='width: 400px'>" +
                    "<b>Address Book Menu:</b><br><br>" +
                    "1. Add a person<br>" +
                    "2. Search for a person by last name<br>" +
                    "3. Delete a person by last name<br>" +
                    "4. Print person details<br>" +
                    "5. Print birthdays in a given month<br>" +
                    "6. Print people between last names<br>" +
                    "7. Exit</body></html>";

            String choiceStr = JOptionPane.showInputDialog(null, menu, "Address Book", JOptionPane.PLAIN_MESSAGE);

            if (choiceStr == null) {
                JOptionPane.showMessageDialog(null, "Input was cancelled. Exiting the program.");
                break;
            }

            int choice;
            try {
                choice = Integer.parseInt(choiceStr);
            } catch (NumberFormatException e) {
                JOptionPane.showMessageDialog(null, "Invalid input. Please enter a number.");
                continue;
            }

            switch (choice) {
                case 1:
                    String firstName = JOptionPane.showInputDialog("Enter first name: ");
                    String lastName = JOptionPane.showInputDialog("Enter last name: ");
                    String street = JOptionPane.showInputDialog("Enter street address: ");
                    String city = JOptionPane.showInputDialog("Enter city: ");
                    String zipCode = JOptionPane.showInputDialog("Enter ZIP code: ");
                    String monthStr = JOptionPane.showInputDialog("Enter birth month(1-12): ");
                    String dayStr = JOptionPane.showInputDialog("Enter birth day(1-31): ");
                    String yearStr = JOptionPane.showInputDialog("Enter birth year(e.g. 2004): ");
                    String phoneNumber = JOptionPane.showInputDialog("Enter phone number: ");
                    String personType = JOptionPane.showInputDialog("Enter person type (family/friend/business): ");

                    try {
                        int month = Integer.parseInt(monthStr);
                        int day = Integer.parseInt(dayStr);
                        int year = Integer.parseInt(yearStr);
                        
                        if (!(personType.equalsIgnoreCase("family") || personType.equalsIgnoreCase("friend") || personType.equalsIgnoreCase("business"))) {
                            JOptionPane.showMessageDialog(null, "Invalid person type.");
                            continue;
                        }
                        
                        addressBook.addPerson(new ExtPerson(firstName, lastName, new Address(street, city, zipCode),
                                        new DateOfBirth(month, day, year), phoneNumber, personType));
                        JOptionPane.showMessageDialog(null, "Person added successfully.");
                    } catch (NumberFormatException e) {
                        JOptionPane.showMessageDialog(null, "Invalid date. Please enter numeric values.");
                    }
                    break;

                case 2:
                    String lastNameToSearch = JOptionPane.showInputDialog("Enter the last name to search for: ");
                    addressBook.printPersonInfo(lastNameToSearch);
                    break;

                case 3:
                    String lastNameToDelete = JOptionPane.showInputDialog("Enter the last name of the person to delete: ");
                    if (addressBook.deletePerson(lastNameToDelete)) {
                        JOptionPane.showMessageDialog(null, "Person deleted.");
                    } else {
                        JOptionPane.showMessageDialog(null, "Person not found.");
                    }
                    break;

                case 4:
                    String lastNameToPrint = JOptionPane.showInputDialog("Enter the last name of the person to print details: ");
                    addressBook.printPersonInfo(lastNameToPrint);
                    break;

                case 5:
                    String monthStrForBirthdays = JOptionPane.showInputDialog("Enter the month to check birthdays: ");
                    String startDateStr = JOptionPane.showInputDialog("Enter the start date: ");
                    String endDateStr = JOptionPane.showInputDialog("Enter the end date: ");
                    try {
                        int monthForBirthdays = Integer.parseInt(monthStrForBirthdays);
                        int startDate = Integer.parseInt(startDateStr);
                        int endDate = Integer.parseInt(endDateStr);
                        addressBook.printBirthdaysInMonth(monthForBirthdays, startDate, endDate);
                    } catch (NumberFormatException e) {
                        JOptionPane.showMessageDialog(null, "Invalid input. Please enter valid numbers.");
                    }
                    break;

                case 6:
                    String startLastName = JOptionPane.showInputDialog("Enter the starting last name: ");
                    String endLastName = JOptionPane.showInputDialog("Enter the ending last name: ");
                    addressBook.printPeopleBetweenLastNames(startLastName, endLastName);
                    break;

                case 7:
                    JOptionPane.showMessageDialog(null, "Exiting the Address Book.");
                    System.exit(0);

                default:
                    JOptionPane.showMessageDialog(null, "Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
