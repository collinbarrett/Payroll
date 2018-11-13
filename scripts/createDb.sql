CREATE USER 'payroll'@'localhost' IDENTIFIED BY 'password';
CREATE DATABASE payrolldata CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_520_ci;
GRANT ALL PRIVILEGES ON payrolldata.* TO 'payroll'@'localhost';
FLUSH PRIVILEGES;