INSERT into PATIENTS (lname, mname, fname, hc_num, policy_num, phone_number, p_email)
VALUES ('Taifour', NULL, 'Ashraf', '98321735', '35149658', '135-426-4895', 'at@gmail.com');

INSERT into PATIENTS (lname, mname, fname, hc_num, policy_num, phone_number, p_email)
VALUES ('ElChami', NULL, 'Moe', '98765432', '98765432', '459-223-1549', 'me@gmail.com');

INSERT into PATIENTS (lname, mname, fname, hc_num, policy_num, phone_number, p_email)
VALUES ('Briguglio', NULL, 'Spencer', '654987321', '654987321', '195-479-5643', 'sb@gmail.com');

INSERT into PATIENTS (lname, mname, fname, hc_num, policy_num, phone_number, p_email)
VALUES ('Smith', 'Carrol', 'Will', '47531258', '14785364', '519-753-1495', 'ws@gmail.com');

INSERT into CLINIC(reg_num, name, address, phone_number)
VALUES ('0987654321', 'LAClinics', '1239 Malden Rd', '226-479-5312');

INSERT into CLINIC(reg_num, name, address, phone_number)
VALUES ('1234567890', 'WCLINICS', '2145 Walker Rd',	'519-476-3245');

INSERT into CLINIC(reg_num, name, address, phone_number)
VALUES ('3549152248', 'Windsor Health', '9573 Dougall Ave', '519-950-4400');

INSERT into HEALTHCARE_PERSONNEL(lname, fname, Password, phone_number, salary, email, role)
VALUES ('Doe', 'John', 'jd123456', '519-247-5493',	300000.0000,	'jd@gmail.com',	'md');

INSERT into HEALTHCARE_PERSONNEL(lname, fname, Password, phone_number, salary, email, role)
VALUES ('Gregs', 'Nancy', 'ng123456', '519-473-5132', 30000.0000, 'ng@gmail.com',	'administration');

INSERT into HEALTHCARE_PERSONNEL(lname, fname, Password, phone_number, salary, email, role)
VALUES ('Joy', 'Rhonda', 'rj123456', '519-765-8563', 80000.0000, 'rj@gmail.com', 'nurse');

INSERT into HEALTHCARE_PERSONNEL(lname, fname, Password, phone_number, salary, email, role)
VALUES ('Dark',	'Calvin', 'cd123456', '519-651-3548', 350000.0000, 'dc@gmail.com', 'md');

INSERT into HEALTHCARE_PERSONNEL(lname, fname, Password, phone_number, salary, email, role)
VALUES ('Kirby', 'George', 'gk123456', '519-472-1354', 25000.0000, 'gk@gmail.com', 'administration');

INSERT into HEALTHCARE_PERSONNEL(lname, fname, Password, phone_number, salary, email, role)
VALUES ('Cahn', 'Hans', 'hc123456', '519-2345-3000', 85000.0000, 'hc@gmail.com', 'nurse');

INSERT into APPOINTMENT(time)
VALUES ('2020-10-23 10:00:00');

INSERT into APPOINTMENT(time)
VALUES ('2020-10-23 11:00:00');

INSERT into APPOINTMENT(time)
VALUES ('2020-10-23 12:30:00');

INSERT into APPOINTMENT(time)
VALUES ('2020-10-23 10:30:00');

INSERT into APPOINTMENT(time)
VALUES ('2020-10-23 14:00:00');

INSERT into ATTENDS(appid, empid)
VALUES (1, 1);

INSERT into ATTENDS(appid, empid)
VALUES (2, 3);

INSERT into ATTENDS(appid, empid)
VALUES (4, 3);
