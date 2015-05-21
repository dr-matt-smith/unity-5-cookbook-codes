CREATE TABLE `cookbook_highscores` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `player` varchar(25) NOT NULL,
  `score` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;