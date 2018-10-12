CREATE DATABASE 'turner_broadcasting'

CREATE TABLE project (
     `proj_id` INT NOT NULL AUTO_INCREMENT,
     `name` VARCHAR(50) NOT NULL,
     PRIMARY KEY (proj_id)
)COLLATE='utf8_bin';

CREATE TABLE employee (
     `emp_id` INT NOT NULL AUTO_INCREMENT,
     `name` VARCHAR(50) NOT NULL,
     `ssn` VARCHAR(50) NOT NULL,
     `proj_id` INT NOT NULL,
     `manager_id` int(11) DEFAULT NULL,
     PRIMARY KEY (emp_id),
     FOREIGN KEY (manager_id) REFERENCES employee(emp_id),
     FOREIGN KEY (proj_id) REFERENCES project(proj_id)
)COLLATE='utf8_bin';

INSERT INTO `project` (`proj_id`, `name`) VALUES
(1, 'projname1'),
(2, 'projname2'),
(3, 'projname3'),
(4, 'projname4');

INSERT INTO `employee` (`emp_id`, `name`, `ssn`, `proj_id`, `manager_id`) VALUES
(1, 'name1', '123456789', 2, 2),
(2, 'name2', '123456789', 3),
(3, 'name3', '123456789', 2, 1),
(4, 'name4', '123456789', 4, 3);

INSERT INTO `employee` (`emp_id`, `name`, `ssn`, `proj_id`, `manager_id`) VALUES
(1, 'name1', '123456789', 2, 2),
(2, 'name2', '123456789', 3, ''),
(3, 'name3', '123456789', 2, 1),
(4, 'name4', '123456789', 4, 3);

# SQL Query #1 - Return a list of employee's names and their managers names.
SELECT epy.name as manager_name, mgr.name as employee_name FROM employee AS epy JOIN employee AS mgr ON epy.emp_id = mgr.manager_id